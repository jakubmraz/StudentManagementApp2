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
using NewStudentManagementApp2WebAPI;

namespace NewStudentManagementApp2WebAPI.Controllers
{
    public class Student_ProgrammeController : ApiController
    {
        private StudentManagementaApp2Model db = new StudentManagementaApp2Model();

        // GET: api/Student_Programme
        public IQueryable<Student_Programme> GetStudent_Programme()
        {
            return db.Student_Programme;
        }

        // GET: api/Student_Programme/5
        [ResponseType(typeof(Student_Programme))]
        public IHttpActionResult GetStudent_Programme(int id)
        {
            Student_Programme student_Programme = db.Student_Programme.Find(id);
            if (student_Programme == null)
            {
                return NotFound();
            }

            return Ok(student_Programme);
        }

        // PUT: api/Student_Programme/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStudent_Programme(int id, Student_Programme student_Programme)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != student_Programme.Programme_Id)
            {
                return BadRequest();
            }

            db.Entry(student_Programme).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Student_ProgrammeExists(id))
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

        // POST: api/Student_Programme
        [ResponseType(typeof(Student_Programme))]
        public IHttpActionResult PostStudent_Programme(Student_Programme student_Programme)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Student_Programme.Add(student_Programme);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Student_ProgrammeExists(student_Programme.Programme_Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = student_Programme.Programme_Id }, student_Programme);
        }

        // DELETE: api/Student_Programme/5
        [ResponseType(typeof(Student_Programme))]
        public IHttpActionResult DeleteStudent_Programme(int id)
        {
            Student_Programme student_Programme = db.Student_Programme.Find(id);
            if (student_Programme == null)
            {
                return NotFound();
            }

            db.Student_Programme.Remove(student_Programme);
            db.SaveChanges();

            return Ok(student_Programme);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Student_ProgrammeExists(int id)
        {
            return db.Student_Programme.Count(e => e.Programme_Id == id) > 0;
        }
    }
}