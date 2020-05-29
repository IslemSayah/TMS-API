using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TMS_API.Models;

namespace TMS_API.Dtos
{
    public class InternalNoteDto
    {
        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        [StringLength(255)]
        public string Subject { get; set; }
        [Required]
        [ForeignKey("TicketDto")]
        public string TicketId { get; set; }
        public string NoteText { get; set; }
        [Required]
        [ForeignKey("StaffMemberDto")]
        public string AuthorId { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public TicketDto TicketDto { get; set; }
        public StaffMemberDto StaffMemberDto { get; set; }
    }
}