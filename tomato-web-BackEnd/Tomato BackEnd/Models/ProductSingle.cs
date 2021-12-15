using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Tomato_BackEnd.Models
{
    public class ProductSingle:BaseEntity
    {
        [StringLength(maximumLength:6000)]
        public string  Title { get; set; }
        public double NewPrice { get; set; }
        public string OldPrice { get; set; }
        [StringLength(maximumLength: 6000)]
        public string SingleDesc { get; set; }
        [StringLength(maximumLength: 6000)]
        public string Img { get; set; }
        public bool Isdeleted { get; set; }
        [NotMapped]
        public IFormFile ImgFile { get; set; }
        [StringLength(maximumLength: 6000)]
        public string LongDesc { get; set; }
        [StringLength(maximumLength: 6000)]
        public string Desc1 { get; set; }
        [StringLength(maximumLength: 6000)]
        public string Desc2 { get; set; }
        [StringLength(maximumLength: 6000)]
        public string Desc3 { get; set; }
    }
}
