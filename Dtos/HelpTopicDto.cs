using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TMS_API.Models;

namespace TMS_API.Dtos
{
    public class HelpTopicDto
    {
        [Key]
        [Required]
        [StringLength(255)]
        public string Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Title { get; set; }
        [Required]
        public Status Status { get; set; }
        public Status AutoResponse { get; set; }
        public Priority NewTicketPriority { get; set; }

    }
}