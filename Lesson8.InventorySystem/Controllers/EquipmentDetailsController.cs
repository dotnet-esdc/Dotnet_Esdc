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
    public class EquipmentDetailsController : ApiController
    {
        private InventoryContext db = new InventoryContext();

        // GET: api/EquipmentDetails
        public IQueryable<EquipmentDetail> GetEquipmentDetail()
        {
            return db.EquipmentDetail;
        }

        // GET: api/EquipmentDetails/5
        [ResponseType(typeof(EquipmentDetail))]
        public async Task<IHttpActionResult> GetEquipmentDetail(int id)
        {
            EquipmentDetail equipmentDetail = await db.EquipmentDetail.FindAsync(id);
            if (equipmentDetail == null)
            {
                return NotFound();
            }

            return Ok(equipmentDetail);
        }

        // PUT: api/EquipmentDetails/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEquipmentDetail(int id, EquipmentDetail equipmentDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != equipmentDetail.Id)
            {
                return BadRequest();
            }

            db.Entry(equipmentDetail).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipmentDetailExists(id))
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

        // POST: api/EquipmentDetails
        [ResponseType(typeof(EquipmentDetail))]
        public async Task<IHttpActionResult> PostEquipmentDetail(EquipmentDetail equipmentDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EquipmentDetail.Add(equipmentDetail);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = equipmentDetail.Id }, equipmentDetail);
        }

        // DELETE: api/EquipmentDetails/5
        [ResponseType(typeof(EquipmentDetail))]
        public async Task<IHttpActionResult> DeleteEquipmentDetail(int id)
        {
            EquipmentDetail equipmentDetail = await db.EquipmentDetail.FindAsync(id);
            if (equipmentDetail == null)
            {
                return NotFound();
            }

            db.EquipmentDetail.Remove(equipmentDetail);
            await db.SaveChangesAsync();

            return Ok(equipmentDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EquipmentDetailExists(int id)
        {
            return db.EquipmentDetail.Count(e => e.Id == id) > 0;
        }
    }
}