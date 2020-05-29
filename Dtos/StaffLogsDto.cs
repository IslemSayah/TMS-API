using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TMS_API.Models;

namespace TMS_API.Dtos
{
    public class StaffLogsDto
    {
        [Required]
        [StringLength(255)]
        [ForeignKey("StaffMemberDto")]
        public string StaffMemberId { get; set; }
        [Required]
        public DateTime Datetime { get; set; }
        [Required]
        public Status PreviousSatus { get; set; }
        [Required]
        public Status CurrentStatus { get; set; }
        [Required]
        public TMS_API.Models.Action Action { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public StaffMemberDto StaffMemberDto { get; set; }
    }
}