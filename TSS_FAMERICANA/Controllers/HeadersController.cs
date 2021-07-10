using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using TSS_FAMERICANA.Models;

namespace TSS_FAMERICANA.Controllers
{
    public class HeadersController : ApiController
    {
        private practicaVEntities db = new practicaVEntities();

        // GET: api/Headers
        public IQueryable<Header> GetHeader()
        {
            return db.Header;
        }

        // GET: api/Headers/5
        [ResponseType(typeof(Header))]
        public IHttpActionResult GetHeader(int id)
        {
            Header header = db.Header.Find(id);
            if (header == null)
            {
                return NotFound();
            }

            return Ok(header);
        }

        // PUT: api/Headers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHeader(int id, Header header)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != header.IdHeader)
            {
                return BadRequest();
            }

            db.Entry(header).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HeaderExists(id))
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

        // POST: api/Headers
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [ResponseType(typeof(Header))]
        public IHttpActionResult PostHeader(Header header)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Header.Add(header);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = header.IdHeader }, header);
        }

        // DELETE: api/Headers/5
        [ResponseType(typeof(Header))]
        public IHttpActionResult DeleteHeader(int id)
        {
            Header header = db.Header.Find(id);
            if (header == null)
            {
                return NotFound();
            }

            db.Header.Remove(header);
            db.SaveChanges();

            return Ok(header);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HeaderExists(int id)
        {
            return db.Header.Count(e => e.IdHeader == id) > 0;
        }
    }
}