using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tomato_BackEnd.Models;

namespace Tomato_BackEnd.ViewModels
{
    public class ContactVM
    {
        public virtual List<Settings> Settings { get; set; }
    }
}
