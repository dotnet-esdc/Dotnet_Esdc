using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Lesson8_InventorySystem.Entities;

namespace Lesson8_InventorySystem.Controllers
{
    public class InventoryFactsController : ApiController
    {
        private InventoryContext db = new InventoryContext();

        // GET: api/InventoryFacts
        public IQueryable<InventoryFact> GetInventoryFact()
        {
            return db.InventoryFact;
        }

        // GET: api/InventoryFacts/5
        [ResponseType(typeof(InventoryFact))]
        public async Task<IHttpActionResult> GetInventoryFact(int id)
        {
            InventoryFact inventoryFact = await db.InventoryFact.FindAsync(id);
            if (inventoryFact == null)
            {
                return NotFound();
            }

            return Ok(inventoryFact);
        }

        // PUT: api/InventoryFacts/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutInventoryFact(int id, InventoryFact inventoryFact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != inventoryFact.Id)
            {
                return BadRequest();
            }

            db.Entry(inventoryFact).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventoryFactExists(id))
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

        // POST: api/InventoryFacts
        [ResponseType(typeof(InventoryFact))]
        public async Task<IHttpActionResult> PostInventoryFact(InventoryFact inventoryFact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.InventoryFact.Add(inventoryFact);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = inventoryFact.Id }, inventoryFact);
        }

        // DELETE: api/InventoryFacts/5
        [ResponseType(typeof(InventoryFact))]
        public async Task<IHttpActionResult> DeleteInventoryFact(int id)
        {
            InventoryFact inventoryFact = await db.InventoryFact.FindAsync(id);
            if (inventoryFact == null)
            {
                return NotFound();
            }

            db.InventoryFact.Remove(inventoryFact);
            await db.SaveChangesAsync();

            return Ok(inventoryFact);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InventoryFactExists(int id)
        {
            return db.InventoryFact.Count(e => e.Id == id) > 0;
        }
    }
}