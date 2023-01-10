using CourseProject.Areas.Identity.Data;
using CourseProject.Data;
using CourseProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CourseProject.Controllers
{
    public class ReviewController : Controller
    {
        private DataContext _context;
        private SignInManager<AddFieldToUser> _signInManager;

        public ReviewController(DataContext context, SignInManager<AddFieldToUser> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
        }

        // GET: ReviewController
        public async Task<IActionResult> Index(long id)
        {
            //Review review = await _context.Reviews.FindAsync(id);
            return View();
        }

        // GET: ReviewController/Details/5
        public async Task<IActionResult> Details(long id)
        {
            Review review = await _context.Reviews.FindAsync(id);
            return View(review);
        }

        // GET: ReviewController/Create
        public IActionResult Create()
        {
            if (_signInManager.IsSignedIn(User))
            {
                return View();
            }

            return RedirectToRoute(new 
            {
                area = "Identity",
                controller = "User",
                action = "AccessDenied"
            });
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

    }
}
