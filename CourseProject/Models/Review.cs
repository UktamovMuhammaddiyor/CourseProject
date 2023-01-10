using System.ComponentModel.DataAnnotations;

namespace CourseProject.Models
{
    public class Review
    {
        public long Id { get; set; }
        [Required]
        public string RiviewName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Group { get; set; }
        [Required]
        [Range(0, 10)]
        public int Grade { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
        [Display(Name = "Image")]
        public string ImageUrl { get; set; } = "";

        public long LikesCount { get; set; } = 0;
        public long StarsCount { get; set; } = 0;
        public long StarsSum { get; set; } = 0;
        public IEnumerable<LikedUsersId> LikedUsersIds { get; set; }
        public IEnumerable<ReviewedUsersId> ReviewedUsersIds { get; set; }

        public IEnumerable<Comment> Comments { get; set; }

    }
}
