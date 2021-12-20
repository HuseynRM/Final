using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tomato_BackEnd.ViewModels
{
    public class MemberLoginModel
    {
        [DataType(DataType.EmailAddress), StringLength(maximumLength: 500)]
        public string Email { get; set; }
        [StringLength(maximumLength: 50), DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
