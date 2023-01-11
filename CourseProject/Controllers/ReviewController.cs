using CourseProject.Areas.Identity.Data;
using CourseProject.Data;
using CourseProject.Models;
using CourseProject.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Controllers
{
    public class ReviewController : Controller
    {
        private DataContext _context;
        private SignInManager<AddFieldToUser> _signInManager;
        private UserManager<AddFieldToUser> _userManager;

        public ReviewController(DataContext context, SignInManager<AddFieldToUser> signInManager, UserManager<AddFieldToUser> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        // GET: ReviewController
        public IActionResult Index()
        {
            //Review review = await _context.Reviews.FindAsync(id);
            return View();
        }

        // GET: ReviewController/Details/5
        public async Task<IActionResult> Details(long id)
        {
            Review review = await _context.Reviews.Include(l => l.LikedUsersIds).FirstOrDefaultAsync(r => r.Id == id);
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var like = review.LikedUsersIds.FirstOrDefault(l => l.userId == user.Id);

            ReviewViewModel reviewVM = new ReviewViewModel
            {
                Id = review.Id,
                RiviewName = review.RiviewName,
                Description = review.Description,
                Grade = review.Grade,
                Group = review.Group,
                Tags = review.Tags,
                ImageUrl = review.ImageUrl,
                createdTime = review.createdTime,
                StarsCount = review.StarsCount,
                StarsSum = review.StarsSum,
                LikedUsersIds = review.LikedUsersIds,
                ReviewedUsersIds = review.ReviewedUsersIds,
                Comments = review.Comments,
                isLiked = false,
                userId = user.UserName
            };

            if (like != null)
            {
                reviewVM.isLiked = true;
            }

            return View(reviewVM);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReviewController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Review reviewVM)
        {
            if (ModelState.IsValid)
            {
                await _context.Reviews.AddRangeAsync(reviewVM);
                await _context.SaveChangesAsync();

                return RedirectToAction("details", new { id = reviewVM.Id});
            }

            return View(reviewVM);
        }

        public IActionResult List()
        {
            var review = _context.Reviews;

            return View(review);
        }
    }
}
