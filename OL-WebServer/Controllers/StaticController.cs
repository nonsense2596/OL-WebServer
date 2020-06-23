using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApiTeszt2.Controllers
{
    public class StaticController : Controller
    {
        // 
        // GET: /Static/
        public IActionResult Index()
        {
            ViewBag.ShowTopBar = true;
            ViewBag.Left = new HeaderLink("Mobile", "../Mobile");
            ViewBag.Mid = new HeaderLink("Static", "../Static");
            ViewBag.Right = new HeaderLink("Home", "../Home");
            return View();
        }
    }
}