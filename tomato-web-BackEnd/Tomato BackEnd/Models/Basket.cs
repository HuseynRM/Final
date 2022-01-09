using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tomato_BackEnd.Models
{
    public class Basket:BaseEntity
    {
        public string AppUserId { get; set; }
        public int ShopListId { get; set; }
        public int Count { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public virtual AppUser AppUser { get; set; }
        public virtual  ShopList ShopList { get; set; }
    }
}
