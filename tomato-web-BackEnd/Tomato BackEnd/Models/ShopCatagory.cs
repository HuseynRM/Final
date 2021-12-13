using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tomato_BackEnd.Models
{
    public class ShopCatagory:BaseEntity
    {
        public string CName { get; set; }
        public ICollection<ShopList> ShopLists { get; set; }

    }
}
