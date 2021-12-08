using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tomato_BackEnd.Models
{
    public class Settings:BaseEntity
    {
        [StringLength(maximumLength:4000)]
        public string Location { get; set; }
        [StringLength(maximumLength: 4000)]
        public string Phone { get; set; }
        [StringLength(maximumLength: 4000)]
        public string Mail { get; set; }
        [StringLength(maximumLength: 4000)]
        public string Facebook { get; set; }
        [StringLength(maximumLength: 4000)]
        public string Twitter { get; set; }
        [StringLength(maximumLength: 4000)]
        public string Google { get; set; }
        [StringLength(maximumLength: 4000)]
        public string YouTube { get; set; }
        [StringLength(maximumLength: 4000)]
        public string Pinteres { get; set; }
        [StringLength(maximumLength: 4000)]
        public string LinkIn { get; set; }
    }
}
