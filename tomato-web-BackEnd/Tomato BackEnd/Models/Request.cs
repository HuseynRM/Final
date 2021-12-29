using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tomato_BackEnd.Enums;

namespace Tomato_BackEnd.Models
{
    public class Request:BaseEntity
    {
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int ReservationInfoId { get; set; }
        public ReservationInfo ReservationInfo { get; set; }
        public string UserName { get; set; }
        public DateTime RequestDate { get; set; }
        public RequestStatus Status { get; set; }

    }
}
