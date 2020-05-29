using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TMS_API.Models
{
    public class TicketFile
    {
        [Key]
        public Guid Id { get; set; }
        public Guid TicketId { get; set; }
        public string FilePath { get; set; }

        [ForeignKey("TicketId")]
        public Ticket Ticket { get; set; }
    }
}