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
using Lesson11.MyODataService.Models;

namespace Lesson11.MyODataService.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using Lesson11.MyODataService.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Categories>("Categories");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class CategoriesController : ODataController
    {
        private MyApplicationDbContext db = new MyApplicationDbContext();

        // GET: odata/Categories
        [EnableQuery]
        public IQueryable<Categories> GetCategories()
        {
            return db.Categories;
        }

        // GET: odata/Categories(5)
        [EnableQuery]
        public SingleResult<Categories> GetCategories([FromODataUri] int key)
        {
            return SingleResult.Create(db.Categories.Where(categories => categories.Id == key));
        }

        // PUT: odata/Categories(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Categories> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Categories categories = await db.Categories.FindAsync(key);
            if (categories == null)
            {
                return NotFound();
            }

            patch.Put(categories);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriesExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(categories);
        }

        // POST: odata/Categories
        public async Task<IHttpActionResult> Post(Categories categories)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Categories.Add(categories);
            await db.SaveChangesAsync();

            return Created(categories);
        }

        // PATCH: odata/Categories(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Categories> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Categories categories = await db.Categories.FindAsync(key);
            if (categories == null)
            {
                return NotFound();
            }

            patch.Patch(categories);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriesExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(categories);
        }

        // DELETE: odata/Categories(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Categories categories = await db.Categories.FindAsync(key);
            if (categories == null)
            {
                return NotFound();
            }

            db.Categories.Remove(categories);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategoriesExists(int key)
        {
            return db.Categories.Count(e => e.Id == key) > 0;
        }
    }
}
