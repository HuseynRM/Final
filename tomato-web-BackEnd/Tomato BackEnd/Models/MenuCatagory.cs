using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tomato_BackEnd.Models
{
    public class MenuCatagory:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<MenuList> MenuLists { get; set; }

    }
}
