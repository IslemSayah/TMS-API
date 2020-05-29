using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TMS_API.Models
{
    public class TicketThreadMessage
    {
       
        public DateTime DateTime { get; set; }
     
    
        public Guid? TicketId { get; set; }
        public string MessageText { get; set; }
       
        public Guid? StaffAuthorId { get; set;  }

        public Guid? UserAuthorId { get; set; }

        [Key]
      
        public Guid? Id { get; set; }



        [ForeignKey("TicketId")]
        public Ticket Ticket { get; set; }
        [ForeignKey("StaffAuthorId")]
        public StaffMember StaffAuthor { get; set; }
        [ForeignKey("UserAuthorId")]
        public User UserAuthor { get; set; }
    }
}