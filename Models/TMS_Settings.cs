using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TMS_API.Models
{
    public class TMS_Settings
    {
      [Required]
     [StringLength(255)]
     public string SettingTitle { get; set; }
        [Required]
        [StringLength(255)]
        public string Type { get; set; }
        [Required]
        public bool IsNull { get; set; }
        [Required]
        [StringLength(255)]
        public string Value { get; set; }
        [Required]
        [StringLength(255)]
        public string Default { get; set; }
        [Required]
        [StringLength(255)]
        public string Subject { get; set;  }
        [Key]
    
        public Guid Id { get; set; }

    }
}