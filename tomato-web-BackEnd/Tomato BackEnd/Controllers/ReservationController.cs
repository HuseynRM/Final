using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tomato_BackEnd.DAL;
using Tomato_BackEnd.Models;
using Tomato_BackEnd.ViewModels;

namespace Tomato_BackEnd.Controllers
{
    public class ReservationController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public ReservationController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            ReservationVM reservationVM = new ReservationVM()
            {
                
            };
            return View(reservationVM);
        }
        public IActionResult GetReservation(ReservationInfo reservationInfo)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("index");
            }
            _context.ReservationInfo.Add(reservationInfo);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
