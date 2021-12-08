using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tomato_BackEnd.Models
{
    public class AboutStory:BaseEntity
    {
        [StringLength(maximumLength: 3000)]
        public string StoryImg { get; set; }
        [NotMapped]
        public IFormFile StoryImgFile { get; set; }
        [StringLength(maximumLength: 5000)]
        public string StoryContent { get; set; }
    }
}
