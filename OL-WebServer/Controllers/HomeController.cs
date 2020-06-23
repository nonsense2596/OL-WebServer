using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApiTeszt2.Controllers
{
    public class HomeController : Controller
    {
        // 
        // GET: /Home/
        public IActionResult Index()
        {
            ViewBag.ShowTopBar = false;
            return View();
        }
    }
}