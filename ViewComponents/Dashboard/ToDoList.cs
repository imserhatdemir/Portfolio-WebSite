using BusinnessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.ViewComponents.Dashboard
{
    public class ToDoList : ViewComponent
    {
        ToDoListManager toDoListManager = new ToDoListManager(new EFToDoListDAL());

        public IViewComponentResult Invoke()
        {
            var value = toDoListManager.TGetList();
            return View(value);
        }
    }
}
