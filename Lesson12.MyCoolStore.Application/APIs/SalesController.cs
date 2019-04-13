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
    builder.EntitySet<Sale>("Sales");
    builder.EntitySet<Employee>("Employees"); 
    builder.EntitySet<SaleDetail>("SaleDetails"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class SalesController : ODataController
    {
        private MyCoolStoreContext db = new MyCoolStoreContext();

        // GET: odata/Sales
        [EnableQuery]
        public IQueryable<Sale> GetSales()
        {
            return db.Sales;
        }

        // GET: odata/Sales(5)
        [EnableQuery]
        public SingleResult<Sale> GetSale([FromODataUri] int key)
        {
            return SingleResult.Create(db.Sales.Where(sale => sale.Id == key));
        }

        // PUT: odata/Sales(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Sale> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Sale sale = db.Sales.Find(key);
            if (sale == null)
            {
                return NotFound();
            }

            patch.Put(sale);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SaleExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(sale);
        }

        // POST: odata/Sales
        public IHttpActionResult Post(Sale sale)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sales.Add(sale);
            db.SaveChanges();

            return Created(sale);
        }

        // PATCH: odata/Sales(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Sale> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Sale sale = db.Sales.Find(key);
            if (sale == null)
            {
                return NotFound();
            }

            patch.Patch(sale);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SaleExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(sale);
        }

        // DELETE: odata/Sales(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Sale sale = db.Sales.Find(key);
            if (sale == null)
            {
                return NotFound();
            }

            db.Sales.Remove(sale);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Sales(5)/Employee
        [EnableQuery]
        public SingleResult<Employee> GetEmployee([FromODataUri] int key)
        {
            return SingleResult.Create(db.Sales.Where(m => m.Id == key).Select(m => m.Employee));
        }

        // GET: odata/Sales(5)/FactDetails
        [EnableQuery]
        public IQueryable<SaleDetail> GetFactDetails([FromODataUri] int key)
        {
            return db.Sales.Where(m => m.Id == key).SelectMany(m => m.FactDetails);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SaleExists(int key)
        {
            return db.Sales.Count(e => e.Id == key) > 0;
        }
    }
}
