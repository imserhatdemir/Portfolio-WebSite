using BusinnessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.ViewComponents.Experience
{
    public class ExperienceList : ViewComponent
    {
        ExperienceManager featureManager = new ExperienceManager(new EFExperienceDAL());
        public IViewComponentResult Invoke()
        {
            var values = featureManager.TGetList();
            return View(values);
        }
    }
}
