using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tomato_BackEnd.Models;

namespace Tomato_BackEnd.ViewModels
{
    public class ProductListVM
    {
        public virtual List<ShopCatagory> ShopCatagorys { get; set; }
        public virtual List<ShopList> ShopLists { get; set; }
        public ProductSingle ProductSingle { get; set; }
    }
}
