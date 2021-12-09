using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tomato_BackEnd.Models
{
    public class Contact:BaseEntity
    {
        //[Required]
        [StringLength(maximumLength: 900)]
        public string FullName { get; set; }
        [StringLength(maximumLength: 900)]
        //[Required]
        [EmailAddress(ErrorMessage = "E-Mail yazin !!!")]
        public string Mail { get; set; }
        //[Required]
        [StringLength(maximumLength: 900)]
        public string Subject { get; set; }
        [StringLength(maximumLength: 9000)]
        //[Required]
        public string Message { get; set; }
    }
}
