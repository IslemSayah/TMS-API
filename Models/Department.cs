using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TMS_API.Models
{
    public class Department
    {
     
        [Key]
        
        public Guid Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Title { get; set; }
        public bool IsDefault { get; set; }
   


        [ForeignKey("StaffMember")]
        public Guid? ManagerId { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAdress { get; set; }

        public StaffMember StaffMember { get; set; }
    }
}