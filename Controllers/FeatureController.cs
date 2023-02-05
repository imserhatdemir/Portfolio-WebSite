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
    public class FeatureController : Controller
    {
        FeatureManager featureManager = new FeatureManager(new EFFeatureDAL());

        [HttpGet]
        public IActionResult Index()
        {
            var values = featureManager.GetById(1);
            return View(values);
        }

        [HttpPost]
        public IActionResult Index(Feature s)
        {
            FeatureValidator validationRules = new FeatureValidator();
            ValidationResult result = validationRules.Validate(s);
            if (result.IsValid)
            {
                featureManager.TUpdate(s);
                return RedirectToAction("Index","Default");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
            
        }
    }
}
