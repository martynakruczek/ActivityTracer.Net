using ActivityTracker.Models;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace ApiTest.Controllers
{
    public class RawDataController : ApiController
    {
        private StepsDbContext db = new StepsDbContext();

        // GET: api/RawData
        public IQueryable<RawData> GetRawData()
        {
            return db.ListOfRawData;
        }

        // GET: api/RawData/5
        [Route("getUserRawData/{userId}")]
        public IQueryable<RawData> GetUserRawData(string userId)
        {
            return db.ListOfRawData.Where(x => x.ApplicationUserID == userId);
        }

        // POST: api/RawData
        [ResponseType(typeof(Steps))]
        public IHttpActionResult PostRawData(RawData rawData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ListOfRawData.Add(rawData);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = rawData.Id }, rawData);
        }
    }
}
