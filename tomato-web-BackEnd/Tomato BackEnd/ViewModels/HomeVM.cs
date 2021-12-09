using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tomato_BackEnd.Models;

namespace Tomato_BackEnd.ViewModels
{
    public class HomeVM
    {
        public virtual List<Settings> Settings { get; set; }
        public RestaurantHome RestaurantHome { get; set; }
        public List<HomeSpecial> HomeSpecials { get; set; }

    }
}
