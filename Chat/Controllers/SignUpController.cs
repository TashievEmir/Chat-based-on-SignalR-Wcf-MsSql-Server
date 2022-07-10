using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Chat.ServiceReferenceWcf;
namespace Chat.Controllers
{
    public class SignUpController:Controller
    {
        Service1Client client=new Service1Client();
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(string name, string password)
        {
            client.AddUser(name, password);
            return Redirect("/Home/Index");
        }
    }
}