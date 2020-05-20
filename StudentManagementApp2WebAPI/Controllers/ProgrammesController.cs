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
using StudentManagementApp2WebAPI;

namespace StudentManagementApp2WebAPI.Controllers
{
    public class ProgrammesController : ApiController
    {
        private StudentManagementDBContext db = new StudentManagementDBContext();

        // GET: api/Programmes
        public IQueryable<Programme> GetProgrammes()
        {
            return db.Programmes;
        }

        // GET: api/Programmes/5
        [ResponseType(typeof(Programme))]
        public IHttpActionResult GetProgramme(int id)
        {
            Programme programme = db.Programmes.Find(id);
            if (programme == null)
            {
                return NotFound();
            }

            return Ok(programme);
        }

        // PUT: api/Programmes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProgramme(int id, Programme programme)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != programme.Programme_Id)
            {
                return BadRequest();
            }

            db.Entry(programme).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProgrammeExists(id))
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

        // POST: api/Programmes
        [ResponseType(typeof(Programme))]
        public IHttpActionResult PostProgramme(Programme programme)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Programmes.Add(programme);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = programme.Programme_Id }, programme);
        }

        // DELETE: api/Programmes/5
        [ResponseType(typeof(Programme))]
        public IHttpActionResult DeleteProgramme(int id)
        {
            Programme programme = db.Programmes.Find(id);
            if (programme == null)
            {
                return NotFound();
            }

            db.Programmes.Remove(programme);
            db.SaveChanges();

            return Ok(programme);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProgrammeExists(int id)
        {
            return db.Programmes.Count(e => e.Programme_Id == id) > 0;
        }
    }
}