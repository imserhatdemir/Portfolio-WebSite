using BusinnessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.ViewComponents.Testimonials
{
    public class TestimonialsList : ViewComponent
    {
        TestimonialsManager featureManager = new TestimonialsManager(new EFTestimonialsDAL());
        public IViewComponentResult Invoke()
        {
            var values = featureManager.TGetList();
            return View(values);
        }
    }
}
