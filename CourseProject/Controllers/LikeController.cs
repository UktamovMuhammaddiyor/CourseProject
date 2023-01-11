using CourseProject.Areas.Identity.Data;
using CourseProject.Data;
using CourseProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LikeController : ControllerBase
    {
        private DataContext _context;
        private UserManager<AddFieldToUser> _userManager;

        public LikeController(DataContext context, UserManager<AddFieldToUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> LikeReview( string userName, long reviewId)
        {
            var error = "You weren't accepted.";
            var password = Request.Headers.Accept;

            if (password == "Courseproject")
            {
                var user = await _userManager.FindByNameAsync(userName);

                if (user != null)
                {
                    var review = await _context.Reviews.Include(l => l.LikedUsersIds).FirstOrDefaultAsync(r => r.Id == reviewId);
                    
                    if (review == null)
                    {
                        error = "Review deleted or not found";
                    }
                    else
                    {
                        foreach (var userid in review.LikedUsersIds)
                        {
                            if (userid.userId == user.Id)
                            {
                                return Ok(new { error = "User Liked Before" });
                            }
                        }

                        Review reviewName = await _context.Reviews.FindAsync(reviewId);

                        await _context.LikedUsersIds.AddRangeAsync(new LikedUsersId
                        {
                            userId = user.Id,
                            Review = reviewName
                        });
                        reviewName.LikesCount += 1;

                        await _context.SaveChangesAsync();

                        return Ok(new { succeed = "User Liked" });
                    }
                }
            }

            return Ok(new { error });
        }
    }
}
