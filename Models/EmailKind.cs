using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMS_API.Models
{
    public enum EmailKind
    {
        TicketOpened, 
        TicketClosed,
        TicketAssigned, 
        TicketOverdue,
        TicketDeleted
    }
}