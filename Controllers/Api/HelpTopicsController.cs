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
    public class HelpTopicsController : ApiController
    {
        private MyDbContext db = new MyDbContext();

        // GET: api/HelpTopics
        public IQueryable<HelpTopic> GetHelpTopics()
        {
            return db.HelpTopics;
        }

        // GET: api/HelpTopics/5
        [ResponseType(typeof(HelpTopic))]
        public IHttpActionResult GetHelpTopic(Guid id)
        {
            HelpTopic helpTopic = db.HelpTopics.Find(id);
            if (helpTopic == null)
            {
                return NotFound();
            }

            return Ok(helpTopic);
        }

        // PUT: api/HelpTopics/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHelpTopic(Guid id, HelpTopic helpTopic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != helpTopic.Id)
            {
                return BadRequest();
            }

            db.Entry(helpTopic).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HelpTopicExists(id))
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

        // POST: api/HelpTopics
        [ResponseType(typeof(HelpTopic))]
        public IHttpActionResult PostHelpTopic(HelpTopic helpTopic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HelpTopics.Add(helpTopic);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (HelpTopicExists(helpTopic.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = helpTopic.Id }, helpTopic);
        }

        // DELETE: api/HelpTopics/5
        [ResponseType(typeof(HelpTopic))]
        public IHttpActionResult DeleteHelpTopic(Guid id)
        {
            HelpTopic helpTopic = db.HelpTopics.Find(id);
            if (helpTopic == null)
            {
                return NotFound();
            }

            db.HelpTopics.Remove(helpTopic);
            db.SaveChanges();

            return Ok(helpTopic);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HelpTopicExists(Guid id)
        {
            return db.HelpTopics.Count(e => e.Id == id) > 0;
        }
    }
}