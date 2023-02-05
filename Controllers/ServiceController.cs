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
    public class ServiceController : Controller
    {
        ServiceManager serviceManager = new ServiceManager(new EFServiceDAL());
        public IActionResult Index()
        {
            var value = serviceManager.TGetList();
            return View(value);
        }


        [HttpGet]
        public IActionResult AddService()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddService(Service s)
        {
            ServiceValidator validationRules = new ServiceValidator();
            ValidationResult result = validationRules.Validate(s);
            if (result.IsValid)
            {
                serviceManager.TAdd(s);
                return RedirectToAction("Index");
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

        public IActionResult DeleteService(int id)
        {
            var value = serviceManager.GetById(id);
            serviceManager.TDelete(value);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult EditService(int id)
        {
            var value = serviceManager.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult EditService(Service s)
        {
            ServiceValidator validationRules = new ServiceValidator();
            ValidationResult result = validationRules.Validate(s);
            if (result.IsValid)
            {
                serviceManager.TUpdate(s);
                return RedirectToAction("Index");
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
