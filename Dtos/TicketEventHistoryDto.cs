using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TMS_API.Models;

namespace TMS_API.Dtos
{
    public class TicketEventHistoryDto
    {
        [Required]
        [StringLength(255)]
        public string TicketId { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        [DefaultValue("NewTicket")]
        public TicketWorkflow PreviousStatus { get; set; }
        [Required]
        [DefaultValue("NewTicket")]
        public TicketWorkflow CurrentStatus { get; set; }
        [Required]
        [StringLength(255)]
        public string DoerId { get; set; }
        [Required]
        public Event Event { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [ForeignKey("TicketId")]
        public TicketDto TicketDto { get; set; }
        [ForeignKey("DoerId")]
        public StaffMemberDto Doer { get; set; }
    }
}