using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TMS_API.Models
{
    public class StaffGroup
    {
        [Key]
        
        public Guid Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Title { get; set; }
        [Required]
        public Status Status { get; set; }
        [Required]
        public bool CanCreateTickets { get; set; }
        [Required]
        public bool CanEditTickets { get; set; }
        [Required]
        public bool CanCloseTickets { get; set; }
        [Required]
        public bool CanTransferTickets { get; set; }
        [Required]
        public bool CanDeleteTickets { get; set; }
        [Required]
        public bool CanBanEmails { get; set; }


    }
}