namespace CourseProject.Models
{
    public class Comment
    {
        public long Id { get; set; }

        public string Text { get; set; }

        public long ReviewId { get; set; }

        public IEnumerable<Review> Reviews { get; set; }
    }
}
