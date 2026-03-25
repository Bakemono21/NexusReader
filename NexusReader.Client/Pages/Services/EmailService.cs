using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace NexusReader.Services
{
    public class EmailService
    {
        private readonly HttpClient _httpClient;

        // We inject HttpClient so we can talk to our backend API
        public EmailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task SendVerificationCodeAsync(string recipientEmail, string code)
        {
            // We package the email and code into a simple object
            var emailRequest = new 
            { 
                Email = recipientEmail, 
                Code = code 
            };

            // We send an HTTP POST request to our backend API
            // (Note: We will build this backend API URL in the next step!)
            var response = await _httpClient.PostAsJsonAsync("https://localhost:5087/api/email/send", emailRequest);

            if (!response.IsSuccessStatusCode)
            {
                throw new System.Exception("Failed to send email. The backend server reported an error.");
            }
        }
    }
}