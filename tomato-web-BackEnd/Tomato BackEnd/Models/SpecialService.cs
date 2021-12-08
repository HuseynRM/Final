using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Linq;
using System.Threading.Tasks;

namespace Tomato_BackEnd.Models
{
    public class SpecialService:BaseEntity
    {
        [StringLength(maximumLength: 3000)]
        public string ServiceIMg { get; set; }
        [NotMapped]
        public IFormFile ServiceIMgFile { get; set; }
        [StringLength(maximumLength: 3000)]

        public string ServiceTitle { get; set; }
        [StringLength(maximumLength: 3000)]
        public string ServiceDesc { get; set; }
    }
}
