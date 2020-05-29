using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TMS_API.Models;
using License = TMS_API.Models.License;

namespace TMS_API.ViewModels
{
    public class TicketViewModel
    {
        [Key]
        public Guid Id { get; set; }


        [ForeignKey("User")]
        public Guid UserId { get; set; }

        [ForeignKey("License")]
        public Guid? LicenseId { get; set; }

        [DefaultValue("NewTicket")]
        public TicketWorkflow? TicketStatus { get; set; }

        [StringLength(255)]
        public string Subject { get; set; }

        public string Message { get; set; }

        public TicketSource? Source { get; set; }

        public DateTime? CreationDateTime { get; set; }

        public DateTime? DueDate { get; set; }
        public DateTime? LastResponse { get; set; }
        public DateTime? LastMessage { get; set; }


        public int? Number { get; set; }

        [DefaultValue("false")]
        public bool? IsOverdue { get; set; }



        public Guid? AssignedStaffId { get; set; }



        public Guid? LastRespondentId { get; set; }



        public Guid? EditorStaffId { get; set; }

        [DefaultValue("None")]

        public Guid? HelpTopicId { get; set; }

        public bool? IsCreatedByStaff { get; set; }



        public Guid? CreatorStaffId { get; set; }

        public List<HttpPostedFileBase> Files { get; set; }
        public string[] Paths { get; set; }
        //=============================================
        [ForeignKey("UserId")]
        public User User { get; set; }
        [ForeignKey("HelpTopicId")]
        public HelpTopic HelpTopic { get; set; }
        [ForeignKey("AssignedStaffId")]
        public StaffMember AssignedStaff { get; set; }
        [ForeignKey("LastRespondentId")]
        public StaffMember LastRespondent { get; set; }
        [ForeignKey("CreatorStaffId")]
        public StaffMember CreatorStaff { get; set; }
        [ForeignKey("EditorStaffId")]
        public StaffMember EditorStaff { get; set; }
        [ForeignKey("LicenseId")]
        public License License { get; set; }
    }
}