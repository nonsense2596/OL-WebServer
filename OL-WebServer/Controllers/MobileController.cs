using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApiTeszt2.Controllers
{
    public class MobileController : Controller
    {
        // 
        // GET: /Mobile/
        public IActionResult Index()
        {
            ViewBag.ShowTopBar = true;
            ViewBag.Left = new HeaderLink("Static", "../Static");
            ViewBag.Mid = new HeaderLink("Mobile", "../Mobile");
            ViewBag.Right = new HeaderLink("Home", "../Home");
            return View();
        }
    }
}