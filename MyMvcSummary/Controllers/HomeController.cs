using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyMvcSummary.Models;

namespace MyMvcSummary.Controllers
{
    public class HomeController : Controller,IHubs
    {
        Random Rnd = new Random();
        public ActionResult Index()
        {
           
            return View();
        }
        public ActionResult Chat()
        {
            return View();
        }
        public ActionResult PersistentChat()
        {
            ViewBag.ClientName = "用户-" + Rnd.Next(10000, 99999);
            return View();
        }
        public ActionResult ChatRoom() {
            return View();
        }


        public System.Threading.Tasks.Task OnConnected()
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        {
            throw new NotImplementedException();
        }
    }
}
