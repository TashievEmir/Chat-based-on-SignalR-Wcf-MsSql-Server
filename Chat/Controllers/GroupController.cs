using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Chat.ServiceReferenceWcf;
namespace Chat.Controllers
{
    public class GroupController:Controller
    {
        Service1Client client=new Service1Client();
        public ActionResult Group()
        {
            ViewData["SenderId"] = Session["SenderId"];
            ViewData["SenderColor"] = Session["SenderColor"];
            ViewData["SenderName"] = Session["SenderName"];
            var messages = client.GetGroupMessages();
            return View(messages);
        }
    }
}