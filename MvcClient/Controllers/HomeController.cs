using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcClient;

namespace MvcClient.Controllers
{
    public class HomeController : Controller
    {
        readonly ServiceChat.Service1Client client = new ServiceChat.Service1Client();
        public ActionResult Chat()
        {
            if (Session["LoginUser"] == null || string.IsNullOrEmpty(Session["LoginUser"].ToString()))
                return RedirectToAction("Index");
            else
            {
                ViewBag.Username = Session["LoginUser"].ToString();
                Session["LoginUser"] = null;
                return View();
            }
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(ServiceChat.User a)
        {
            Session["LoginUser"] = a.Name;
            return RedirectToAction("Chat");
        }
    }
}