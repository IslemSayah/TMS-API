using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TMS_API.Models;

namespace TMS_API.Dtos
{
    public class TicketThreadMessageDto
    {
        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        [StringLength(255)]

        public string TicketId { get; set; }
        public string MessageText { get; set; }

        public string StaffAuthorId { get; set; }

        public string UserAuthorId { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }



        [ForeignKey("TicketId")]
        public TicketDto Ticket { get; set; }
        [ForeignKey("StaffAuthorId")]
        public StaffMemberDto StaffAuthor { get; set; }
        [ForeignKey("UserAuthorId")]
        public UserDto UserAuthor { get; set; }
    }
}