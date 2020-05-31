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
    public class StaffMembersController : ApiController
    {
        private MyDbContext db = new MyDbContext();

        // GET: api/StaffMembers
        public IQueryable<StaffMember> GetStaffMembers()
        {
            return db.StaffMembers;
        }

        // GET: api/StaffMembers/5
        [ResponseType(typeof(StaffMember))]
        public IHttpActionResult GetStaffMember(Guid id)
        {
            StaffMember staffMember = db.StaffMembers.Find(id);
            if (staffMember == null)
            {
                return NotFound();
            }

            return Ok(staffMember);
        }

        // PUT: api/StaffMembers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStaffMember(Guid id, StaffMember staffMember)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != staffMember.Id)
            {
                return BadRequest();
            }

            db.Entry(staffMember).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StaffMemberExists(id))
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

        // POST: api/StaffMembers
        [ResponseType(typeof(StaffMember))]
        public IHttpActionResult PostStaffMember(StaffMember staffMember)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            staffMember.Id = Guid.NewGuid();

            db.StaffMembers.Add(staffMember);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (StaffMemberExists(staffMember.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = staffMember.Id }, staffMember);
        }

        // DELETE: api/StaffMembers/5
        [ResponseType(typeof(StaffMember))]
        public IHttpActionResult DeleteStaffMember(Guid id)
        {
            StaffMember staffMember = db.StaffMembers.Find(id);
            if (staffMember == null)
            {
                return NotFound();
            }

            db.StaffMembers.Remove(staffMember);
            db.SaveChanges();

            return Ok(staffMember);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StaffMemberExists(Guid id)
        {
            return db.StaffMembers.Count(e => e.Id == id) > 0;
        }
    }
}