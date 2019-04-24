using Lesson13.CustomHRApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Lesson13.CustomHRApplication.Api
{
    public class ApplicationUsersController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ICollection<ApplicationUser> Get()
        {
            /* TODO
             * It is a not savety code
             * not use it in production
             */

            var users = db.Users.Select(x => new { x.Id, x.UserName }).ToList();

            return users.Select(x => new ApplicationUser()
            {
                Id = x.Id,
                UserName = x.UserName
            }).ToList();
        }
    }
}
