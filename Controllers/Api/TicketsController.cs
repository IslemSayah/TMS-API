using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TMS_API.Models;
using TMS_API.ViewModels;
using AutoMapper;
using System.IO;
using System.Configuration;

namespace TMS_API.Controllers.Api
{
    public class TicketsController : ApiController
    {
        private MyDbContext _context;

        public TicketsController()
        {
            _context = new MyDbContext(); 
        }


        //User Api-==================================
        /*  [HttpPost]
          public IHttpActionResult CreateTicket(Ticket Ticket)
          {
              if (!ModelState.IsValid)
                  return BadRequest();

              Ticket.Id = Guid.NewGuid();
              Ticket.CreationDateTime = DateTime.Now;
              DateTime DueDate = DateTime.Now.AddMonths(1);
              Ticket.DueDate = DueDate;
              Ticket.IsOverdue = false;
              var number = _context.Tickets.Count();
              Ticket.Number = number;
              _context.Tickets.Add(Ticket);
              _context.SaveChanges();

              return Created(new Uri(Request.RequestUri + "/" + Ticket.Id), Ticket);

          }*///


        [HttpPost]
        public IHttpActionResult CreateTicket(Ticket ticket)
        {
            if (!ModelState.IsValid)
                return BadRequest();



            /* foreach (System.Web.HttpPostedFileBase f in ticket.Files)
              {
                  var FilePath = new TicketFile();
                  FilePath.Id = Guid.NewGuid();
                  FilePath.TicketId = Ticket.Id;

                  string FileName = Path.GetFileNameWithoutExtension(f.FileName);

              //To Get File Extension  
              string FileExtension = Path.GetExtension(f.FileName);

              //Add Current Date To Attached File Name  
              FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + FileName.Trim() + FileExtension;

              //Get Upload path from Web.Config file AppSettings.  
              string UploadPath = ConfigurationManager.AppSettings["C:/Users/Utilisateur/source/repos/TMS-API/Files/"].ToString();

              //Its Create complete path to store in server.  
              FilePath.FilePath = UploadPath + FileName;

              //To copy and save file into server.  
               f.SaveAs(FilePath.FilePath);
                  _context.TicketFiles.Add(FilePath);
                  _context.SaveChanges();

              }*/
            //var Ticket = Mapper.Map<TicketViewModel, Ticket>(ticket);
            var Ticket = ticket;
            Ticket.Id = Guid.NewGuid();
            Ticket.UserId = Guid.NewGuid();
            Ticket.CreationDateTime = DateTime.Now;
            DateTime DueDate = DateTime.Now.AddMonths(1);
            Ticket.DueDate = DueDate;
            Ticket.IsOverdue = false;
            var number = _context.Tickets.Count();
            Ticket.Number = number;
           
            _context.Tickets.Add(Ticket);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + Ticket.Id), Ticket);

        }

        [HttpGet]
        public IEnumerable<Ticket> GetTicketsByUser(Guid UserId)
        { 

            var tickets = _context.Set<Ticket>().Where(t => t.UserId == UserId);
            if (tickets == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

             return tickets;
        }

        [HttpGet]
        public IEnumerable<TicketThreadMessage> GetThreadMessagesByTicketId(Guid TicketId)
        {

            var messages = _context.Set<TicketThreadMessage>().Where(m => m.TicketId == TicketId);
            if (messages == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return messages;
         }

        [HttpGet]
        public IEnumerable<HelpTopic> GetHelpTopics()
        {

            var HelpTopics = _context.HelpTopics.ToList();
            if (HelpTopics == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return HelpTopics;

         }
         
        [HttpGet]
        public HelpTopic GetHelpTopicById(Guid HelpTopicId)
        {
            var HelpTopic = _context.HelpTopics.SingleOrDefault(h => h.Id == HelpTopicId);
            if (HelpTopic == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return HelpTopic;

        }

        [HttpGet]
        public IEnumerable<Ticket> GetTicketsByHelpTopicId(Guid HelpTopicId) {

            var tickets = _context.Set<Ticket>().Where(t => t.HelpTopicId == HelpTopicId);
            if (tickets == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return tickets;
         }

        [HttpPost]
        public IHttpActionResult AddTicketThreadMessage(TicketThreadMessage message)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _context.TicketThreadMessages.Add(message);
            _context.SaveChanges();
            return Created(new Uri(Request.RequestUri + "/" + message.Id), message);
         }

        [HttpPut]
        public IHttpActionResult CloseTicket(Guid TicketId )
        {
            var ticket = _context.Tickets.SingleOrDefault(t => t.Id == TicketId);
            if (ticket == null)
                return BadRequest();

            ticket.TicketStatus = TicketWorkflow.ClosedTicket;
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + ticket.Id), ticket);
         }









        //User Api-==================================


        
        //StaffApi==========================
        
        [HttpPost]
        public IEnumerable<Ticket> GetTicketAssigned(Guid MemberId)
        {
            var tickets = _context.Set<Ticket>().Where(t => t.AssignedStaffId == MemberId);
           
            if (tickets == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return tickets;
        }


        [HttpPut]
        public IHttpActionResult OpenTicket(Guid TicketId, Guid StaffId)
        {
            var ticket = _context.Tickets.SingleOrDefault(t => t.Id == TicketId);
            if (ticket == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);


            ticket.TicketStatus = TicketWorkflow.OpenedTicket;
            ticket.AssignedStaffId = StaffId;
            ticket.TicketStatus = TicketWorkflow.AssignedTicket;
            ticket.LastRespondentId = StaffId;
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + ticket.Id), ticket);
        }

        [HttpPost]
        public IHttpActionResult AddInternalNote(Guid TicketId , InternalNote Note, Guid StaffId)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var ticket = _context.Tickets.SingleOrDefault(t => t.Id == TicketId);

            if ( ticket == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Note.TicketId = TicketId;
            Note.Id = Guid.NewGuid();
            Note.AuthorId = StaffId;
            _context.InternalNotes.Add(Note);

            return Created(new Uri(Request.RequestUri + "/" + Note.Id), Note);
         }

       
        [HttpPut]
        public IHttpActionResult EditTicket(Guid TicketId, Ticket Ticket)
        {
            if (!ModelState.IsValid)
                return BadRequest();
           
            if(! (TicketId == Ticket.Id) )
                return BadRequest();

            var ticket = _context.Tickets.SingleOrDefault(t => t.Id == TicketId);

            if (ticket == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Ticket.Id = ticket.Id;
            ticket = Ticket;
            _context.SaveChanges();
            return Created(new Uri(Request.RequestUri + "/" + Ticket.Id), Ticket);


        }







        [HttpGet]
        public IEnumerable<Ticket> GetTickets()
        {
            return _context.Tickets.ToList();
        }

       
        
        [HttpGet]
        public Ticket GetTicketById(Guid id)
        {
            var ticket = _context.Tickets.SingleOrDefault(c => c.Id == id);
            if (ticket == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);


            return ticket;

        }

      
        
        [HttpGet]
        public Ticket GetTicketBySubject(string id)
        {
            var ticket = _context.Tickets.SingleOrDefault(c => c.Subject == id);
            if (ticket == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);


            return ticket;
         }

        





    }
}
