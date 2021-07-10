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
    public class DetailController : ApiController
    {
        private practicaVEntities db = new practicaVEntities();

        // GET: api/Detail
        public IQueryable<Detail> GetDetail()
        {
            return db.Detail;
        }

        // GET: api/Detail/5
        [ResponseType(typeof(Detail))]
        public IHttpActionResult GetDetail(long id)
        {
            Detail detail = db.Detail.Find(id);
            if (detail == null)
            {
                return NotFound();
            }

            return Ok(detail);
        }

        // PUT: api/Detail/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDetail(long id, Detail detail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != detail.IdEmpleado)
            {
                return BadRequest();
            }

            db.Entry(detail).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetailExists(id))
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

        // POST: api/Detail
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [ResponseType(typeof(Detail))]
        public IHttpActionResult PostDetail(Detail detail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Detail.Add(detail);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = detail.IdEmpleado }, detail);
        }

        // DELETE: api/Detail/5
        [ResponseType(typeof(Detail))]
        public IHttpActionResult DeleteDetail(long id)
        {
            Detail detail = db.Detail.Find(id);
            if (detail == null)
            {
                return NotFound();
            }

            db.Detail.Remove(detail);
            db.SaveChanges();

            return Ok(detail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DetailExists(long id)
        {
            return db.Detail.Count(e => e.IdEmpleado == id) > 0;
        }
    }
}