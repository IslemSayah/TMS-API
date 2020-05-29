using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TMS_API.Models
{
    public class MyDbContext : System.Data.Entity.DbContext
    {
        public MyDbContext()
        {
        }

        protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

       
        }
        public System.Data.Entity.DbSet<Ticket> Tickets { get; set; }
        public System.Data.Entity.DbSet<Department> Departments { get; set; }
        public System.Data.Entity.DbSet<HelpTopic> HelpTopics { get; set; }
        public System.Data.Entity.DbSet<InternalNote> InternalNotes { get; set; }
        public System.Data.Entity.DbSet<License> Licenses { get; set; }
        public System.Data.Entity.DbSet<StaffGroup> StaffGroups { get; set; }
        public System.Data.Entity.DbSet<StaffLogs> StaffLogs { get; set; }
        public System.Data.Entity.DbSet<StaffMember> StaffMembers { get; set; }
        public System.Data.Entity.DbSet<TicketEventsHistory> TicketsEventHistory { get; set; }
        public System.Data.Entity.DbSet<TicketThreadMessage> TicketThreadMessages { get; set; }
        public System.Data.Entity.DbSet<TMS_Settings> TMS_Settings { get; set; }
        public System.Data.Entity.DbSet<User> Users { get; set; }
        public System.Data.Entity.DbSet<TicketFile> TicketFiles { get; set; }
    }
}