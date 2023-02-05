using BusinnessLayer.Concrete;
using BusinnessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Controllers
{
    public class AboutController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EFAboutDAL());

        [HttpGet]
        public IActionResult Index()
        {
            var value = aboutManager.GetById(1);
            return View(value);
        }

        [HttpPost]
        public IActionResult Index(About s)
        {
            AboutValidator validationRules = new AboutValidator();
            ValidationResult result = validationRules.Validate(s);
            if (result.IsValid)
            {
                aboutManager.TUpdate(s);
                return RedirectToAction("Index","Default");
            }
            else
            {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
