namespace NexusReader.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Author { get; set; } = "";
        public string Category { get; set; } = "Romance";
        public string ColorTheme { get; set; } = "blush";
        public string Description { get; set; } = "";
        public string? CoverImage { get; set; }
        public int Progress { get; set; }
        
        // Use this to store all writing data
        public List<ChapterModel> Chapters { get; set; } = new();
    }

    public class ChapterModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Content { get; set; } = "";
    }
}