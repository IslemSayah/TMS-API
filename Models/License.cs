using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TMS_API.Models
{
    public class License
    {
        [Key]
        
        public Guid Id { get; set; }
        [Required]
        [StringLength(255)]
        public string SoftwareEditionId { get; set; }
      
        public Guid? CustomerID { get; set; }
        
        public Guid? UserID { get; set;}
        [Required]
        [StringLength(255)]
        public string MacAdress { get; set; }

        public User User { get; set; }
    }
}