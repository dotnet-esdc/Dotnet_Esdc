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
    builder.EntitySet<OrgUnit>("OrgUnits");
    builder.EntitySet<Staff>("Staffs"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class OrgUnitsController : ODataController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: odata/OrgUnits
        [EnableQuery]
        public IQueryable<OrgUnit> GetOrgUnits()
        {
            return db.OrgUnits;
        }

        // GET: odata/OrgUnits(5)
        [EnableQuery]
        public SingleResult<OrgUnit> GetOrgUnit([FromODataUri] int key)
        {
            return SingleResult.Create(db.OrgUnits.Where(orgUnit => orgUnit.Id == key));
        }

        // PUT: odata/OrgUnits(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<OrgUnit> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            OrgUnit orgUnit = await db.OrgUnits.FindAsync(key);
            if (orgUnit == null)
            {
                return NotFound();
            }

            patch.Put(orgUnit);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrgUnitExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(orgUnit);
        }

        // POST: odata/OrgUnits
        public async Task<IHttpActionResult> Post(OrgUnit orgUnit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.OrgUnits.Add(orgUnit);
            await db.SaveChangesAsync();

            return Created(orgUnit);
        }

        // PATCH: odata/OrgUnits(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<OrgUnit> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            OrgUnit orgUnit = await db.OrgUnits.FindAsync(key);
            if (orgUnit == null)
            {
                return NotFound();
            }

            patch.Patch(orgUnit);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrgUnitExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(orgUnit);
        }

        // DELETE: odata/OrgUnits(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            OrgUnit orgUnit = await db.OrgUnits.FindAsync(key);
            if (orgUnit == null)
            {
                return NotFound();
            }

            db.OrgUnits.Remove(orgUnit);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/OrgUnits(5)/Staffs
        [EnableQuery]
        public IQueryable<Staff> GetStaffs([FromODataUri] int key)
        {
            return db.OrgUnits.Where(m => m.Id == key).SelectMany(m => m.Staffs);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrgUnitExists(int key)
        {
            return db.OrgUnits.Count(e => e.Id == key) > 0;
        }
    }
}
