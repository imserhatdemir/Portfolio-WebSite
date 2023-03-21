using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Areas.Writer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class LoginController : Controller
    {

        private readonly SignInManager<WriterUser> _userManager;

        public LoginController(SignInManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserSignViewModel s)
        {
            if (ModelState.IsValid)
            {
                var result = await _userManager.PasswordSignInAsync(s.UserName, s.Password, true, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Default");
                }
                else
                {
                    ModelState.AddModelError("", "Hatalı Kullanıcı adı veya şifre");
                }
            }
            return View();
        }
    }
}
