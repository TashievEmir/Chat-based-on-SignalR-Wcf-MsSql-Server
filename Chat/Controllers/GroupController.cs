using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Chat.Controllers
{
    public class GroupController:Controller
    {
        public ActionResult Group()
        {
            ViewData["SenderId"] = Session["SenderId"];
            ViewData["SenderColor"] = Session["SenderColor"];
            ViewData["SenderName"] = Session["SenderName"];
            return View();
        }
    }
}