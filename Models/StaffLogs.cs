using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TMS_API.Models
{
    public class StaffLogs
    {
        [Required]
        [ForeignKey("StaffMember")]
        public Guid? StaffMemberId { get; set; }
        [Required]
        public DateTime Datetime { get; set;  }
        [Required]
        public Status PreviousSatus { get; set; }
        [Required]
        public Status CurrentStatus { get; set; }
        [Required]
        public Action Action { get; set;  }

        [Key]
       
        public Guid Id { get; set; }

        public StaffMember StaffMember { get; set; }
    }
}