

using Microsoft.AspNetCore.Mvc;
using BordoProject.Data;
using BordoProject.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BordoProject.Controllers
{

    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var answers = _context.Answers 
                .Include(a => a.Employee)
                .ToList();
            return View(answers);
        }

        public IActionResult Details(int id)
        {
            var answer = _context.Answers 
                .Include(a => a.Employee)
                .FirstOrDefault(a => a.AnswerId == id);
            if (answer == null)
            {
                return NotFound();
            }
            return View(answer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var answer = await _context.Answers.FindAsync(id);
            if (answer == null)
            {
                return NotFound();
            }

            _context.Answers.Remove(answer);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}


//using BordoProject.Data;
//using Microsoft.AspNetCore.Mvc;

//namespace BordoProject.Controllers
//{
//    public class AdminController : Controller
//    {
//        public IActionResult Index()
//        {
//            return View();
//        }
//    }
//}

//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using BordoProject.Data;
//using BordoProject.Models;
//using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;

//using Microsoft.AspNetCore.Identity; // UserManager ve IdentityRole için
//using Microsoft.AspNetCore.Mvc;
//using BordoProject.Data;
//using BordoProject.Models;
//using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;
//using System.Security.Claims;

//namespace BordoProject.Controllers
//{
//    public class AdminController : Controller
//    {
//        private readonly ApplicationDbContext _context;

//private readonly UserManager<ApplicationUser> _userManager;

//public AdminController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
//{
//   _context = context;
//    _userManager = userManager;
//}

//public async Task<IActionResult> CreateAdmin()
//{
//    var user = new ApplicationUser
//    {
//        UserName = "aysenur",
//        Email = "nurayseduvan1@gmail.com",
//        IsAdmin = true
//    };

//    var result = await _userManager.CreateAsync(user, "AdminPassword123!");

//    if (result.Succeeded)
//    {
//        return RedirectToAction("Index");
//    }

//    // Hata mesajlarını işleyin veya kullanıcıya hata mesajı gösterin.
//    foreach (var error in result.Errors)
//    {
//        ModelState.AddModelError(string.Empty, error.Description);
//    }

//    return View();
//}

//public IActionResult Login()
//{

//    return View();
//}
//[HttpPost]

//public async Task<IActionResult> Login(ApplicationUser applicationUser)
//{
//    if (applicationUser.Email == "deneme@gmail.com" && applicationUser.PasswordHash == "12345")
//    {
//        List<Claim> claims = new List<Claim>()
//            {
//            new Claim(ClaimTypes.NameIdentifier,applicationUser.Email),
//            new Claim("Other Properties","Example  Role")
//        };


//    }
//}

//        public IActionResult Index()
//        {
//            var answers = _context.Answers
//                .Include(a => a.Employee)
//                .ToList();
//            return View(answers);
//        }

//        public IActionResult Details(int id)
//        {
//            var answer = _context.Answers
//                .Include(a => a.Employee)
//                .FirstOrDefault(a => a.AnswerId == id);
//            if (answer == null)
//            {
//                return NotFound();
//            }
//            return View(answer);
//        }
//    }
//}
