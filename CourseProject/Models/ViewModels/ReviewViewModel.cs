using System.ComponentModel.DataAnnotations;

namespace CourseProject.Models.ViewModels
{
    public class ReviewViewModel
    {
        public long Id { get; set; }
        public string RiviewName { get; set; }
        public string Description { get; set; }
        public string Group { get; set; }
        public int Grade { get; set; }
        public string Tags { get; set; }
        public string ImageUrl { get; set; } = "";

        public DateTime createdTime { get; set; }

        public long LikesCount { get; set; } = 0;
        public long StarsCount { get; set; } = 0;
        public long StarsSum { get; set; } = 0;
        public IEnumerable<LikedUsersId> LikedUsersIds { get; set; }
        public IEnumerable<ReviewedUsersId> ReviewedUsersIds { get; set; }

        public IEnumerable<Comment> Comments { get; set; }

        public string userId { get; set; }
        public bool isLiked { get; set; }
    }
}
