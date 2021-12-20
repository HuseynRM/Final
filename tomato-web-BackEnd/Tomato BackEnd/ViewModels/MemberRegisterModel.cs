using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tomato_BackEnd.ViewModels
{
    public class MemberRegisterModel
    {
        [DataType(DataType.EmailAddress), StringLength(maximumLength: 500)]
        public string Email { get; set; }
        [StringLength(maximumLength: 500)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [StringLength(maximumLength: 500)]
        [DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmedPassword { get; set; }
    }
}
