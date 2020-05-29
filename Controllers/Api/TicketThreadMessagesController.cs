using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TMS_API.Models;

namespace TMS_API.Controllers.Api
{
    public class TicketThreadMessagesController : ApiController
    {
        private MyDbContext db = new MyDbContext();

        // GET: api/TicketThreadMessages
        public IQueryable<TicketThreadMessage> GetTicketThreadMessages()
        {
            return db.TicketThreadMessages;
        }

        // GET: api/TicketThreadMessages/5
        [ResponseType(typeof(TicketThreadMessage))]
        public IHttpActionResult GetTicketThreadMessage(Guid id)
        {
            TicketThreadMessage ticketThreadMessage = db.TicketThreadMessages.Find(id);
            if (ticketThreadMessage == null)
            {
                return NotFound();
            }

            return Ok(ticketThreadMessage);
        }

        // PUT: api/TicketThreadMessages/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTicketThreadMessage(Guid id, TicketThreadMessage ticketThreadMessage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ticketThreadMessage.Id)
            {
                return BadRequest();
            }

            db.Entry(ticketThreadMessage).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketThreadMessageExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/TicketThreadMessages
        [ResponseType(typeof(TicketThreadMessage))]
        public IHttpActionResult PostTicketThreadMessage(TicketThreadMessage ticketThreadMessage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TicketThreadMessages.Add(ticketThreadMessage);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TicketThreadMessageExists(ticketThreadMessage.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ticketThreadMessage.Id }, ticketThreadMessage);
        }

        

        // DELETE: api/TicketThreadMessages/5
        [ResponseType(typeof(TicketThreadMessage))]
        public IHttpActionResult DeleteTicketThreadMessage(Guid id)
        {
            TicketThreadMessage ticketThreadMessage = db.TicketThreadMessages.Find(id);
            if (ticketThreadMessage == null)
            {
                return NotFound();
            }

            db.TicketThreadMessages.Remove(ticketThreadMessage);
            db.SaveChanges();

            return Ok(ticketThreadMessage);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TicketThreadMessageExists(Guid? id)
        {
            return db.TicketThreadMessages.Count(e => e.Id == id) > 0;
        }
    }
}