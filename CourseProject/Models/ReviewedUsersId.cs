namespace CourseProject.Models
{
    public class ReviewedUsersId
    {
        public long Id { get; set; }

        public string userId { get; set; }

        public long ReviewId { get; set; }

        public Review Review { get; set; }
    }
}
