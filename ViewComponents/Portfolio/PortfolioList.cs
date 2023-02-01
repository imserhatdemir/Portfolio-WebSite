using BusinnessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.ViewComponents.Portfolio
{
    public class PortfolioList : ViewComponent
    {
        PortfolioManager featureManager = new PortfolioManager(new EFPortfolioDAL());
        public IViewComponentResult Invoke()
        {
            var values = featureManager.TGetList();
            return View(values);
        }
    }
}
