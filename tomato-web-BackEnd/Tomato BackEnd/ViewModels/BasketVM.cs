using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tomato_BackEnd.Models;

namespace Tomato_BackEnd.ViewModels
{
    public class BasketVM:BaseEntity
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string Img { get; set; }
        public double NewPrice { get; set; }
        public int Count { get; set; }


    }
}
