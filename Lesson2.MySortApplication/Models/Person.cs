using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2.MySortApplication.Models
{
    public class Person
    {
        public string FullName { get; set; }

        public int Age { get; set; }

        public Gender Gender { get; set; }

        public int Rating { get; set; }

    }

    public enum Gender
    {
        Male,
        Female
    }
}
