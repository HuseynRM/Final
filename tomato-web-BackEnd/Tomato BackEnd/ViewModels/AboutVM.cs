using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tomato_BackEnd.Models;

namespace Tomato_BackEnd.ViewModels
{
    public class AboutVM
    {
        public virtual AboutStory AboutStory { get; set; }
        public virtual List<SpecialService> SpecialServices { get; set; }
        public virtual List<AboutTeam> AboutTeams { get; set; }
        public virtual List<AboutTestimonial> AboutTestimonials { get; set; }


    }
}
