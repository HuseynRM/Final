using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tomato_BackEnd.Models
{
    public class AboutTeam:BaseEntity
    {
        [StringLength(maximumLength: 3000)]
        public string TeamImg { get; set; }
        [NotMapped]
        public IFormFile TeamImgFile { get; set; }
        [StringLength(maximumLength: 3000)]
        public string CookName { get; set; }
        [StringLength(maximumLength: 3000)]
        public string Designation { get; set; }
        [StringLength(maximumLength: 3000)]
        public string Facebook { get; set; }
        [StringLength(maximumLength: 3000)]
        public string Twiter { get; set; }
        [StringLength(maximumLength: 3000)]
        public string Google { get; set; }
    }
}
