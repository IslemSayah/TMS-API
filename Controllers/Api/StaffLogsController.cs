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
    public class StaffLogsController : ApiController
    {
        private MyDbContext db = new MyDbContext();

        // GET: api/StaffLogs
        public IQueryable<StaffLogs> GetStaffLogs()
        {
            return db.StaffLogs;
        }

        // GET: api/StaffLogs/5
        [ResponseType(typeof(StaffLogs))]
        public IHttpActionResult GetStaffLogs(Guid id)
        {
            StaffLogs staffLogs = db.StaffLogs.Find(id);
            if (staffLogs == null)
            {
                return NotFound();
            }

            return Ok(staffLogs);
        }

        // PUT: api/StaffLogs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStaffLogs(Guid id, StaffLogs staffLogs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != staffLogs.Id)
            {
                return BadRequest();
            }

            db.Entry(staffLogs).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StaffLogsExists(id))
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

        // POST: api/StaffLogs
        [ResponseType(typeof(StaffLogs))]
        public IHttpActionResult PostStaffLogs(StaffLogs staffLogs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StaffLogs.Add(staffLogs);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (StaffLogsExists(staffLogs.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = staffLogs.Id }, staffLogs);
        }

        // DELETE: api/StaffLogs/5
        [ResponseType(typeof(StaffLogs))]
        public IHttpActionResult DeleteStaffLogs(Guid id)
        {
            StaffLogs staffLogs = db.StaffLogs.Find(id);
            if (staffLogs == null)
            {
                return NotFound();
            }

            db.StaffLogs.Remove(staffLogs);
            db.SaveChanges();

            return Ok(staffLogs);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StaffLogsExists(Guid id)
        {
            return db.StaffLogs.Count(e => e.Id == id) > 0;
        }
    }
}