using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Tomato_BackEnd.Models
{
    public class HomeSpecial:BaseEntity
    {
        [StringLength(maximumLength:4000)]
        public string SepialImg { get; set; }
        [NotMapped]
        public IFormFile SpecialImgFile { get; set; }
        [StringLength(maximumLength: 4000)]
        public string SpecialName { get; set; }
        [StringLength(maximumLength: 4000)]
        public string Text { get; set; }
        [StringLength(maximumLength: 4000)]
        public string Text1 { get; set; }


    }
}
