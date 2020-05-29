using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TMS_API.Models
{
    public class InternalNote
    {
        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        [StringLength(255)]
        public string Subject { get; set; }
      
        [ForeignKey("Ticket")]
        public Guid? TicketId { get; set; }
        public string NoteText { get; set; }
        [Required]
        [ForeignKey("StaffMember")]
        public Guid? AuthorId { get; set; }

        [Key]
       
        public Guid? Id { get; set; }

        public Ticket Ticket { get; set; }
        public StaffMember StaffMember { get; set; }
    }
}