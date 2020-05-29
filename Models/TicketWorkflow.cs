using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMS_API.Models
{
    public enum TicketWorkflow
    {
        OpenedTicket, 
        ClosedTicket,
        AssignedTicket,
        OverdueTicket,
        NewTicket
    }
}