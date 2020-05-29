using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TMS_API.Models
{
    public class HelpTopic
    {    
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Title { get; set; }
        [Required]
        public Status Status { get; set; }
        public Status AutoResponse { get; set; }
        public Priority NewTicketPriority { get; set; }
       
    }
}