using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using Lesson12_MyCoolStore_Application.Entities;

namespace Lesson12_MyCoolStore_Application.APIs
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using Lesson12_MyCoolStore_Application.Entities;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<SaleDetail>("SaleDetails");
    builder.EntitySet<Product>("Products"); 
    builder.EntitySet<Sale>("Sales"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class SaleDetailsController : ODataController
    {
        private MyCoolStoreContext db = new MyCoolStoreContext();

        // GET: odata/SaleDetails
        [EnableQuery]
        public IQueryable<SaleDetail> GetSaleDetails()
        {
            return db.SaleDetails;
        }

        // GET: odata/SaleDetails(5)
        [EnableQuery]
        public SingleResult<SaleDetail> GetSaleDetail([FromODataUri] int key)
        {
            return SingleResult.Create(db.SaleDetails.Where(saleDetail => saleDetail.Id == key));
        }

        // PUT: odata/SaleDetails(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<SaleDetail> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            SaleDetail saleDetail = db.SaleDetails.Find(key);
            if (saleDetail == null)
            {
                return NotFound();
            }

            patch.Put(saleDetail);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SaleDetailExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(saleDetail);
        }

        // POST: odata/SaleDetails
        public IHttpActionResult Post(SaleDetail saleDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SaleDetails.Add(saleDetail);
            db.SaveChanges();

            return Created(saleDetail);
        }

        // PATCH: odata/SaleDetails(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<SaleDetail> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            SaleDetail saleDetail = db.SaleDetails.Find(key);
            if (saleDetail == null)
            {
                return NotFound();
            }

            patch.Patch(saleDetail);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SaleDetailExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(saleDetail);
        }

        // DELETE: odata/SaleDetails(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            SaleDetail saleDetail = db.SaleDetails.Find(key);
            if (saleDetail == null)
            {
                return NotFound();
            }

            db.SaleDetails.Remove(saleDetail);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/SaleDetails(5)/Product
        [EnableQuery]
        public SingleResult<Product> GetProduct([FromODataUri] int key)
        {
            return SingleResult.Create(db.SaleDetails.Where(m => m.Id == key).Select(m => m.Product));
        }

        // GET: odata/SaleDetails(5)/Sale
        [EnableQuery]
        public SingleResult<Sale> GetSale([FromODataUri] int key)
        {
            return SingleResult.Create(db.SaleDetails.Where(m => m.Id == key).Select(m => m.Sale));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SaleDetailExists(int key)
        {
            return db.SaleDetails.Count(e => e.Id == key) > 0;
        }
    }
}
