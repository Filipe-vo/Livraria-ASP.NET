using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstApplication.Controllers
{
    public class HelloWorldController : Controller
    {
        //GET: HelloWorld
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Custom (string nome, int ID = 1)
        {
            ViewBag.Message = $"Hello, {nome}!";
            return View();
        }

       
    }
}