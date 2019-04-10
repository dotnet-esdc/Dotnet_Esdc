using Lesson11.My3tierApplication.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson11.My3tierApplication.Core.Managers
{
    public interface IValidator
    {
        bool Validate(Category category);
    }
}
