using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tomato_BackEnd.ViewModels
{
    public class AppUserVM
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public List<string> Roles { get; set; }
        public bool IsDeleted { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
