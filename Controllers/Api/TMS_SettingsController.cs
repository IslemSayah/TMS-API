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
    public class TMS_SettingsController : ApiController
    {
        private MyDbContext db = new MyDbContext();

        // GET: api/TMS_Settings
        public IQueryable<TMS_Settings> GetTMS_Settings()
        {
            return db.TMS_Settings;
        }

        // GET: api/TMS_Settings/5
        [ResponseType(typeof(TMS_Settings))]
        public IHttpActionResult GetTMS_Settings(Guid id)
        {
            TMS_Settings tMS_Settings = db.TMS_Settings.Find(id);
            if (tMS_Settings == null)
            {
                return NotFound();
            }

            return Ok(tMS_Settings);
        }

        // PUT: api/TMS_Settings/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTMS_Settings(Guid id, TMS_Settings tMS_Settings)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tMS_Settings.Id)
            {
                return BadRequest();
            }

            db.Entry(tMS_Settings).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TMS_SettingsExists(id))
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

        // POST: api/TMS_Settings
        [ResponseType(typeof(TMS_Settings))]
        public IHttpActionResult PostTMS_Settings(TMS_Settings tMS_Settings)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TMS_Settings.Add(tMS_Settings);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TMS_SettingsExists(tMS_Settings.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tMS_Settings.Id }, tMS_Settings);
        }

        // DELETE: api/TMS_Settings/5
        [ResponseType(typeof(TMS_Settings))]
        public IHttpActionResult DeleteTMS_Settings(Guid id)
        {
            TMS_Settings tMS_Settings = db.TMS_Settings.Find(id);
            if (tMS_Settings == null)
            {
                return NotFound();
            }

            db.TMS_Settings.Remove(tMS_Settings);
            db.SaveChanges();

            return Ok(tMS_Settings);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TMS_SettingsExists(Guid id)
        {
            return db.TMS_Settings.Count(e => e.Id == id) > 0;
        }
    }
}