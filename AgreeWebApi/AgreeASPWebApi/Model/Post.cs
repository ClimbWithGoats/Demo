namespace AgreeASPWebApi.Model
{
    public class Post
    {
        public int Id { get; set; }
        public string? Title { get; set; }

        public string? SubTitle { get; set; }
        public string? Description { get; set; }
        public string? Text { get; set; }
        public DateTime? DateTime { get; set; }

    }
}
