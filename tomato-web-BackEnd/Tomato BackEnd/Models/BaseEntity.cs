using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tomato_BackEnd.Models
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
