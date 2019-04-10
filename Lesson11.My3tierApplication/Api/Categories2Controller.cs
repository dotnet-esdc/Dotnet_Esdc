using Lesson11.My3tierApplication.Core.Entities;
using Lesson11.My3tierApplication.Core.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Lesson11.My3tierApplication.Api
{
    public class Categories2Controller : ApiController
    {
        private IManager _mng;

        public Categories2Controller(IManager mng)
        {
            _mng = mng;
        }
        
        [HttpGet]
        public List<Category> Get()
        {
            return _mng.GetCategories().ToList();
        }

        [HttpPost]
        public IHttpActionResult Post(Category item)
        {
            var result = _mng.TryCreate(item);

            if(result)
                return Ok();
            else
                return BadRequest();
        }

        [HttpPut]
        public IHttpActionResult Put(int id, Category item)
        {
            var result = _mng.TryUpdate(id, item);

            if (result)
                return Ok();
            else
                return BadRequest();
        }


        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var result = _mng.TryDelete(id);

            if (result)
                return Ok();
            else
                return BadRequest();
        }

    }
}
