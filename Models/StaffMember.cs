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
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        [StringLength(255)]
        public string LastName { get; set; }
        [Required]
        [StringLength(255)]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAdress { get; set; }
        [Required]
        [Phone]
        public string OfficePhone { get; set; }
        [Required]
        [Phone]
        public string MobilePhone { get; set; }
        [Required]
        [StringLength(255)]
        public string Password { get; set; }
        [Required]
        public Status Status { get; set; }
        [Required]
        public bool IsAdministrator { get; set; }
        [Required]
        public bool IsOnVacation { get; set; }
        [Required]
        public bool IsLoggedIn { get; set; }
        public Guid? StaffGroupId { get; set; }
        public Guid? DepartmentId { get; set; }
    }
}