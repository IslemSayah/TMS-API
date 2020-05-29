using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TMS_API.Models;

namespace TMS_API.Dtos
{
    public class DepartmentDto
    {
        [Required]
        [Key]
        [StringLength(255)]
        public string Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Title { get; set; }
        public bool IsDefault { get; set; }
        [Required]
        [StringLength(255)]

        [ForeignKey("StaffMemberDto")]
        public string ManagerId { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAdress { get; set; }

        public StaffMemberDto StaffMemberDto { get; set; }
    }
}