﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tomato_BackEnd.Models;

namespace Tomato_BackEnd.ViewModels
{
    public class MenuListVM
    {
        public virtual List<MenuList> MenuLists { get; set; }
        public virtual List<MenuCatagory> MenuCatagories { get; set; }



    }
}
