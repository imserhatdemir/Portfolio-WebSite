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
    public class PortfolioController : Controller
    {
        PortfolioManager portfolioManager = new PortfolioManager(new EFPortfolioDAL());
        public IActionResult Index()
        {
            var values = portfolioManager.TGetList();
            return View(values);
        }


        [HttpGet]
        public IActionResult AddPortfolio()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPortfolio(Portfolios s)
        {
            PortfolioValidator validationRules = new PortfolioValidator();
            ValidationResult result = validationRules.Validate(s);
            if (result.IsValid)
            {
                portfolioManager.TAdd(s);
                return RedirectToAction("Index");
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

        public IActionResult DeletePortfolio(int id)
        {
            var value = portfolioManager.GetById(id);
            portfolioManager.TDelete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditPortfolio(int id)
        {
            var value = portfolioManager.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult EditPortfolio(Portfolios s)
        {

            PortfolioValidator validationRules = new PortfolioValidator();
            ValidationResult result = validationRules.Validate(s);
            if (result.IsValid)
            {
                portfolioManager.TUpdate(s);
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
