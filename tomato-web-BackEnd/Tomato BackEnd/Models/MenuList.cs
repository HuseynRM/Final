using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tomato_BackEnd.Models
{
    public class MenuList:BaseEntity
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public double Price { get; set; }
        public MenuCatagory MenuCatagory { get; set; }
        public int MenuCatagoryId { get; set; }

    }
}
