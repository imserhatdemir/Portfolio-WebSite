﻿using BusinnessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.ViewComponents.Dashboard
{
    public class MessageList : ViewComponent
    {
        UserMessageManager message = new UserMessageManager(new EFUserMessageDAL());
        public IViewComponentResult Invoke()
        {
            var value = message.GetUserMessageWithUserService();
            return View(value);
        }
    }
}
