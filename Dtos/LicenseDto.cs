using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TMS_API.Models;

namespace TMS_API.Dtos
{
    public class LicenseDto
    {
        [Key]
        [Required]
        [StringLength(255)]
        public string Id { get; set; }
        [Required]
        [StringLength(255)]
        public string SoftwareEditionId { get; set; }
        [Required]
        [StringLength(255)]
        public string CustomerID { get; set; }

        public string UserID { get; set; }
        [Required]
        [StringLength(255)]
        public string MacAdress { get; set; }

        public UserDto UserDto { get; set; }
    }
}