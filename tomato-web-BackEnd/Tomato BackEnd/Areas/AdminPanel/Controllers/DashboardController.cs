using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tomato_BackEnd.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class DashboardController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
