namespace CourseProject.Models
{
    public class Tag
    {
        public long Id { get; set; }
        public string TagName { get; set; }

        public long ReviewId { get; set; }

        public Review Review { get; set; }
    }
}
