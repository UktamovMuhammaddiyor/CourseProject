namespace CourseProject.Models
{
    public class LikedUsersId
    {
        public long Id { get; set; }

        public string userId { get; set; }

        public long ReviewId { get; set; }

        public Review Review { get; set; }
    }
}
