using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tomato_BackEnd.Models
{
    public class AboutTestimonial:BaseEntity
    {
        [StringLength(maximumLength: 5000)]
        public string QuoteBody { get; set; }
        [StringLength(maximumLength: 5000)]
        public string QuoteAuthor { get; set; }
    }
}
