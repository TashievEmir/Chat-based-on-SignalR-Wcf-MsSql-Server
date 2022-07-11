using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Chat.ServiceReferenceWcf;
namespace Chat.Controllers
{
    public class PrivateController:Controller
    {
        Service1Client client = new Service1Client();
        public ActionResult Private()
        {
            int id = Convert.ToInt32(Session["SenderId"]);
            var users= client.GetUsersWithoutThisId(id);
            return View(users);
        }
        public ActionResult Chat(int id)
        {
            ViewData["SenderId"] = Session["SenderId"];
            ViewData["SenderName"] = Session["SenderName"];
            ViewData["SenderColor"] = Session["SenderColor"];
            ViewData["ReceiverId"] = id;
            int chatId = Convert.ToInt32(ViewData["SenderId"]) + id;
            ViewData["chatId"]=chatId;
            var privateMess = client.GetPrivateMessages();
            return View(privateMess);
        }
    }
}