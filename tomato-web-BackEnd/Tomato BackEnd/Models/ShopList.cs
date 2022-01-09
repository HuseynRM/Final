using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tomato_BackEnd.Models
{
    public class ShopList:BaseEntity
    {
        [StringLength(maximumLength:5000)]
        public string Img { get; set; }
        [NotMapped]
        public IFormFile ImgFile { get; set; }
        [StringLength(maximumLength: 5000)]
        public string FName { get; set; }
        public double Price { get; set; }
        public ShopCatagory ShopCatagory { get; set; }
        public int ShopCatagoryId { get; set; }
        public List<ProductSingle> ProductSingles { get; set; }
        public int? ProductSingleId { get; set; }
        public virtual ICollection<Basket> Baskets { get; set; }
    }
}
