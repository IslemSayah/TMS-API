using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TMS_API.Models
{
    public class StaffMember
    {
        [Key]
       
        public Guid Id { get; set; }
     
        [StringLength(255)]
        public string Name { get; set; }
       
        [StringLength(255)]
        public string LastName { get; set; }
       
        [StringLength(255)]
        public string UserName { get; set; }
      
        [EmailAddress]
        public string EmailAdress { get; set; }
      
        [Phone]
        public string OfficePhone { get; set; }
     
        [Phone]
        public string MobilePhone { get; set; }
     
        [StringLength(255)]
        public string Password { get; set; }
 
        public Status? Status { get; set; }
  
        public bool? IsAdministrator { get; set; }
     
        public bool? IsOnVacation { get; set; }
       
        public bool? IsLoggedIn { get; set; }
        public Guid? StaffGroupId { get; set; }
        public Guid? DepartmentId { get; set; }
    }
}