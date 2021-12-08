using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tomato_BackEnd.Models;

namespace Tomato_BackEnd.ViewModels
{
    public class AboutVM
    {
        public AboutStory AboutStory { get; set; }
        public List<SpecialService> SpecialServices { get; set; }
        public List<AboutTeam> AboutTeams { get; set; }

    }
}
