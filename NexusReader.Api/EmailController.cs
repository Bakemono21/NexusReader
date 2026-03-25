using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace NexusReader.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : ControllerBase
    {
        // Don't forget to put your actual Gmail and App Password here!
        private const string SmtpServer = "smtp.gmail.com";
        private const int SmtpPort = 587;
        private const string SenderEmail = "justineflame322@gmail.com"; 
        private const string SenderPassword = "axtxdwhwnzhzlfqy";

        // This is the endpoint your Blazor app will call
        [HttpPost("send")]
        public async Task<IActionResult> SendEmail([FromBody] EmailRequest request)
        {
            try
            {
                var mailMessage = new MailMessage
                {
                    From = new MailAddress(SenderEmail, "NexusReader Security"),
                    Subject = "Your NexusReader Verification Code",
                    IsBodyHtml = true,
                    Body = BuildProfessionalEmailTemplate(request.Code)
                };

                mailMessage.To.Add(request.Email);

                using var smtpClient = new SmtpClient(SmtpServer, SmtpPort)
                {
                    Credentials = new NetworkCredential(SenderEmail, SenderPassword),
                    EnableSsl = true
                };

                await smtpClient.SendMailAsync(mailMessage);
                return Ok(new { message = "Email sent successfully" });
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { message = "Failed to send email", error = ex.Message });
            }
        }

        private string BuildProfessionalEmailTemplate(string code)
        {
            return $@"
            <div style='font-family: Arial, sans-serif; max-width: 600px; margin: 0 auto; padding: 20px; border: 1px solid #eaeaeb; border-radius: 8px;'>
                <div style='text-align: center; margin-bottom: 30px;'>
                    <h1 style='color: #2c3e50; margin-bottom: 5px;'>NexusReader</h1>
                    <p style='color: #7f8c8d; margin-top: 0; font-size: 16px;'>The ultimate sanctuary for your collection.</p>
                </div>
                <div style='background-color: #f8f9fa; padding: 30px; border-radius: 8px; text-align: center;'>
                    <h2 style='color: #2c3e50; margin-top: 0;'>Verify Your Email</h2>
                    <p style='color: #34495e; font-size: 16px; line-height: 1.5;'>
                        Welcome! To complete your registration, please enter the following verification code:
                    </p>
                    <div style='margin: 30px 0;'>
                        <span style='font-size: 32px; font-weight: bold; letter-spacing: 5px; color: #3498db; background: #ffffff; padding: 15px 25px; border-radius: 6px; border: 1px solid #dee2e6;'>
                            {code}
                        </span>
                    </div>
                </div>
            </div>";
        }
    }

    // This defines the shape of the data coming from Blazor
    public class EmailRequest
    {
        public required string Email { get; set; }
        public required string Code { get; set; }
    }
}