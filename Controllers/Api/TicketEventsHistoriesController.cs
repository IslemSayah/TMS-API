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
    public class TicketEventsHistoriesController : ApiController
    {
        private MyDbContext db = new MyDbContext();

        // GET: api/TicketEventsHistories
        public IQueryable<TicketEventsHistory> GetTicketsEventHistory()
        {
            return db.TicketsEventHistory;
        }

        // GET: api/TicketEventsHistories/5
        [ResponseType(typeof(TicketEventsHistory))]
        public IHttpActionResult GetTicketEventsHistory(Guid id)
        {
            TicketEventsHistory ticketEventsHistory = db.TicketsEventHistory.Find(id);
            if (ticketEventsHistory == null)
            {
                return NotFound();
            }

            return Ok(ticketEventsHistory);
        }

        // PUT: api/TicketEventsHistories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTicketEventsHistory(Guid id, TicketEventsHistory ticketEventsHistory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ticketEventsHistory.Id)
            {
                return BadRequest();
            }

            db.Entry(ticketEventsHistory).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketEventsHistoryExists(id))
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

        // POST: api/TicketEventsHistories
        [ResponseType(typeof(TicketEventsHistory))]
        public IHttpActionResult PostTicketEventsHistory(TicketEventsHistory ticketEventsHistory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TicketsEventHistory.Add(ticketEventsHistory);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TicketEventsHistoryExists(ticketEventsHistory.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ticketEventsHistory.Id }, ticketEventsHistory);
        }

        // DELETE: api/TicketEventsHistories/5
        [ResponseType(typeof(TicketEventsHistory))]
        public IHttpActionResult DeleteTicketEventsHistory(Guid id)
        {
            TicketEventsHistory ticketEventsHistory = db.TicketsEventHistory.Find(id);
            if (ticketEventsHistory == null)
            {
                return NotFound();
            }

            db.TicketsEventHistory.Remove(ticketEventsHistory);
            db.SaveChanges();

            return Ok(ticketEventsHistory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TicketEventsHistoryExists(Guid id)
        {
            return db.TicketsEventHistory.Count(e => e.Id == id) > 0;
        }
    }
}