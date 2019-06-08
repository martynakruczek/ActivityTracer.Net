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
using ActivityTracker.Models;

namespace ApiTest.Controllers
{
    public class StepsController : ApiController
    {
        private StepsDbContext db = new StepsDbContext();

        // GET: api/Steps
        public IQueryable<Steps> GetSteps()
        {
            return db.StepsList;
        }

        [Route("getUserSteps/{userId}")]
        public IQueryable<Steps> GetUserSteps(string userId)
        {
            return db.StepsList.Where(x => x.ApplicationUserID == userId);
        }

        // GET: api/Steps/5
        [ResponseType(typeof(Steps))]
        public IHttpActionResult GetSteps(int id)
        {
            Steps steps = db.StepsList.Find(id);
            if (steps == null)
            {
                return NotFound();
            }

            return Ok(steps);
        }

        // PUT: api/Steps/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSteps(int id, Steps steps)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != steps.Id)
            {
                return BadRequest();
            }

            db.Entry(steps).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StepsExists(id))
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

        // POST: api/Steps
        [ResponseType(typeof(Steps))]
        public IHttpActionResult PostSteps(Steps steps)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StepsList.Add(steps);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = steps.Id }, steps);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StepsExists(int id)
        {
            return db.StepsList.Count(e => e.Id == id) > 0;
        }
    }
}