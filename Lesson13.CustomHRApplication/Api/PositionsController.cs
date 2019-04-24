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
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using Lesson13.CustomHRApplication.Models;

namespace Lesson13.CustomHRApplication.Api
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using Lesson13.CustomHRApplication.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Position>("Positions");
    builder.EntitySet<Staff>("Staffs"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class PositionsController : ODataController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: odata/Positions
        [EnableQuery]
        public IQueryable<Position> GetPositions()
        {
            return db.Positions;
        }

        // GET: odata/Positions(5)
        [EnableQuery]
        public SingleResult<Position> GetPosition([FromODataUri] int key)
        {
            return SingleResult.Create(db.Positions.Where(position => position.Id == key));
        }

        // PUT: odata/Positions(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Position> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Position position = await db.Positions.FindAsync(key);
            if (position == null)
            {
                return NotFound();
            }

            patch.Put(position);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PositionExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(position);
        }

        // POST: odata/Positions
        public async Task<IHttpActionResult> Post(Position position)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Positions.Add(position);
            await db.SaveChangesAsync();

            return Created(position);
        }

        // PATCH: odata/Positions(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Position> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Position position = await db.Positions.FindAsync(key);
            if (position == null)
            {
                return NotFound();
            }

            patch.Patch(position);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PositionExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(position);
        }

        // DELETE: odata/Positions(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Position position = await db.Positions.FindAsync(key);
            if (position == null)
            {
                return NotFound();
            }

            db.Positions.Remove(position);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Positions(5)/Staffs
        [EnableQuery]
        public IQueryable<Staff> GetStaffs([FromODataUri] int key)
        {
            return db.Positions.Where(m => m.Id == key).SelectMany(m => m.Staffs);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PositionExists(int key)
        {
            return db.Positions.Count(e => e.Id == key) > 0;
        }
    }
}
