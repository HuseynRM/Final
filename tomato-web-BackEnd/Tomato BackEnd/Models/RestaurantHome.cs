using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace Tomato_BackEnd.Models
{
    public class RestaurantHome:BaseEntity
    {
        [StringLength(maximumLength:4000)]
        public string HomeImg { get; set; }
        [StringLength(maximumLength: 4000)]
        public string HomeImg1 { get; set; }
        [StringLength(maximumLength: 4000)]
        public string HomeImg2 { get; set; }
        [NotMapped]
        public IFormFile HomeImgFile2 { get; set; }
        [NotMapped]
        public IFormFile HomeImgFile1 { get; set; }
        [NotMapped]
        public IFormFile HomeImgFile { get; set; }
        [StringLength(maximumLength: 4000)]
        public string Info1 { get; set; }
        [StringLength(maximumLength: 4000)]
        public string Info2 { get; set; }
        [StringLength(maximumLength: 4000)]
        public string Signature { get; set; }
    }
}
