using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TMS_API.Models
{
    public class User
    {
        [Key]
     
        public Guid Id { get; set; }
        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(255)]
        public string LastName { get; set; }
        [Required]
        [StringLength(255)]
        public string CreatedById { get; set; }
        [Required]
        [StringLength(255)]

        public string ModifiedById { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        [Required]
        [StringLength(255)]
        public string UserName { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAdress { get; set; }
        [Required]

        public Status Status { get; set; }
        [Required]
        [DefaultValue("true")]
        public bool IsValid { get; set; }
       
        public Guid? SupervisorId { get; set; }
        
        public Guid? CustomerId { get; set; }



    }
}