using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace Tomato_BackEnd.Models
{
    public class Features:BaseEntity
    {
        [StringLength(maximumLength:4000)]
        public string FeatureImg { get; set; }
        [NotMapped]
        public IFormFile FeatureImgFile { get; set; }
        [StringLength(maximumLength: 4000)]
        public string Name { get; set; }
        [StringLength(maximumLength: 7000)]
        public string Desc { get; set; }

    }
}
