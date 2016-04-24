namespace SwashBucklingCore.Models
{
    public class Article
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string ByLine { get; set; }
        public string Author { get; set; }
        public string Body { get; set; }
        public bool PublishStatus { get; set; }
        public string ThumbNailUrl { get; set; }
    }
}