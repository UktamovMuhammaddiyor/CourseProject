namespace CourseProject.Models
{
    public class LikedUsersId
    {
        public string Id { get; set; }

        public long ReviewId { get; set; }

        public Review Review { get; set; }
    }
}
