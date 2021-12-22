using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tomato_BackEnd.Areas.AdminPanel.Controllers
{
    public class HomeController : Controller
    {
        [Area("AdminPanel")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
