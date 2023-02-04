using BusinnessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Controllers
{
    public class SkillController : Controller
    {
        SkillManager skillManager = new SkillManager(new EFSkillDAL());
        public IActionResult Index()
        {
            ViewBag.d1 = "Yetenekler";
            ViewBag.d2 = "Yetenekler";
            var values = skillManager.TGetList();
            return View(values);
        }


        [HttpGet]
        public IActionResult AddSkill()
        {
            ViewBag.d1 = "Yetenek Ekleme";
            ViewBag.d2 = "Yetenekler";
            return View();
        }


        [HttpPost]
        public IActionResult AddSkill(Skill s)
        {
            skillManager.TAdd(s);
            return RedirectToAction("Index");
        }


        public IActionResult DeleteSkill(int id)
        {
            var values = skillManager.GetById(id);
            skillManager.TDelete(values);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult EditSkill(int id)
        {
            var values = skillManager.GetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult EditSkill(Skill s)
        {
            skillManager.TUpdate(s);
            return RedirectToAction("Index");
        }
    }
}
