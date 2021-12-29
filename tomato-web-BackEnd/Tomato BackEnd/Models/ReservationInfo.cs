using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Tomato_BackEnd.Models
{
    public class ReservationInfo:BaseEntity
    {
        [Column(TypeName ="time")]
        public TimeSpan Time { get; set; }
        [Required]
        [StringLength(maximumLength:4000)]
        public string FullName { get; set; }
        [Required]
        [StringLength(maximumLength: 4000)]
        public string Date { get; set; }
        [Required]
        public int GuestCount { get; set; }
        [Required]
        public string Number { get; set; }
        [Required]
        [StringLength(maximumLength: 4000)]
        [EmailAddress(ErrorMessage = "E-Mail yazin !!!")]
        public string Mail { get; set; }
        public List<Request> Requests { get; set; }
    }
}
