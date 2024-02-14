using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UserLogin.Interfaces;
using UserLogin.Models;

namespace UserLogin.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(User model)
        {
            var user = await _userRepository.GetUserByUsernameAsync(model.Username);

            if (user != null && user.Password == model.Password)
            {
                // Redirect to dashboard or home page upon successful login
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "Invalid username or password");
            return View(model);
        }
    }
}