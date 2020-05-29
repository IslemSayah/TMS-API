using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TMS_API.Models
{
    public class TicketEventsHistory
    {
 
        
        public Guid? TicketId { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        [DefaultValue("NewTicket")]
        public TicketWorkflow PreviousStatus { get; set; }
        [Required]
        [DefaultValue("NewTicket")]
        public TicketWorkflow CurrentStatus { get; set; }
        [Required]
     
        public Guid? DoerId { get; set; }
        [Required]
        public Event Event { get; set;}

        [Key]
      
        public Guid Id { get; set; }

        [ForeignKey("TicketId")]
        public Ticket Ticket { get; set; }
        [ForeignKey("DoerId")]
        public StaffMember Doer { get; set; }

    }
}