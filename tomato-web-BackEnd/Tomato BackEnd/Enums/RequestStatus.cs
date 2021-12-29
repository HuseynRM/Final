using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tomato_BackEnd.Enums
{
    public enum RequestStatus
    {
        Pending,
        Accepted,
        AdminReject,
        UserReject,
        Block
    }
}
