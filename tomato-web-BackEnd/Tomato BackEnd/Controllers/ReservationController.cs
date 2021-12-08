﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tomato_BackEnd.DAL;
using Tomato_BackEnd.ViewModels;

namespace Tomato_BackEnd.Controllers
{
    public class ReservationController : Controller
    {
        private readonly AppDbContext _context;
        public ReservationController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            ReservationVM reservationVM = new ReservationVM()
            {
                Settings = await _context.Settings.ToListAsync()
            };
            return View(reservationVM);
        }
    }
}
