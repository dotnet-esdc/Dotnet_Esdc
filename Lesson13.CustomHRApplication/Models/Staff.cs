using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lesson13.CustomHRApplication.Models
{
    public class Staff
    {
        public int Id { get; set; }

        public int OrgUnitId { get; set; }
        public virtual OrgUnit OrgUnit { get; set; }

        public int PositionId { get; set; }
        public virtual Position Position { get; set; }

        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}