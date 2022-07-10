using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Chat.ServiceReferenceWcf;
namespace Chat.Controllers
{
    public class HomeController : Controller
    {
        Service1Client client = new Service1Client();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string name, string password)
        {
            bool check=client.CheckUser(name,password);
            if (check) {
                Users user = client.GetUserByName(name);
                Session["SenderId"] = user.UserId;
                Session["SenderName"] = user.UserName;
                Session["SenderColor"] = user.UserColor;
                return RedirectToAction("ChooseChat", "Home");
            } 
            else return View();
        }

        public ActionResult ChooseChat()
        {
            return View();
        }
    }
}