using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TMS_API.Models; 

namespace TMS_API.Dtos
{
    public class TicketDto
    {
        [Key]
 
        public string Id { get; set; }

        [StringLength(255)]
        [ForeignKey("UserDto")]
        public string UserId { get; set; }
        [StringLength(255)]
        [ForeignKey("LicenseDto")]
        public string LicenseId { get; set; }
      
        [DefaultValue("NewTicket")]
        public TicketWorkflow? TicketStatus { get; set; }
       
        [StringLength(255)]
        public string Subject { get; set; }
   
        public string Message { get; set; }
     
        public TicketSource? Source { get; set; }
       
        public DateTime? CreationDateTime { get; set; }
      
        public DateTime DueDate { get; set; }
        public DateTime? LastResponse { get; set; }
        public DateTime? LastMessage { get; set; }
      
        public int Number { get; set; }
      
        [DefaultValue("false")]
        public bool? IsOverdue { get; set; }
      
        [StringLength(255)]

        public string AssignedStaffId { get; set; }
      
        [StringLength(255)]

        public string LastRespondentId { get; set; }
    
        [StringLength(255)]

        public string EditorStaffId { get; set; }
    
        [StringLength(255)]
        [DefaultValue("None")]

        public string HelpTopicId { get; set; }
      
        public bool? IsCreatedByStaff { get; set; }
   
        [StringLength(255)]

        public string CreatorStaffId { get; set; }
        [ForeignKey("UserId")]
        public UserDto UserDto { get; set; }
        [ForeignKey("HelpTopicId")]
        public HelpTopicDto HelpTopic { get; set; }
        [ForeignKey("AssignedStaffId")]
        public StaffMemberDto AssignedStaff { get; set; }
        [ForeignKey("LastRespondentId")]
        public StaffMemberDto LastRespondent { get; set; }
        [ForeignKey("CreatorStaffId")]
        public StaffMemberDto CreatorStaff { get; set; }
        [ForeignKey("EditorStaffId")]
        public StaffMemberDto EditorStaff { get; set; }
        [ForeignKey("LicenseId")]
        public LicenseDto LicenseDto { get; set; }
    }
}