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
    
        [StringLength(255)]
        public string FirstName { get; set; }
 
        [StringLength(255)]
        public string LastName { get; set; }

        [StringLength(255)]
        public string CreatedById { get; set; }
    
        [StringLength(255)]

        public string ModifiedById { get; set; }
  
        [Phone]
        public string PhoneNumber { get; set; }

        [StringLength(255)]
        public string UserName { get; set; }

        public string PasswordHash { get; set; }
    
        [EmailAddress]
        public string EmailAdress { get; set; }


        public Status? Status { get; set; }

        [DefaultValue("true")]
        public bool? IsValid { get; set; }
       
    
        
      



    }
}