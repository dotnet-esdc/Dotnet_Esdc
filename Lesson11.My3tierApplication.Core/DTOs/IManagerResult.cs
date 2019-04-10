using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson11.My3tierApplication.Core.DTOs
{
    public class ManagerResult<T>
    {
        public bool IsSuccess { get; private set; }

        public string Message { get; private set; }

        public T Result { get; private set; }

        public ManagerResult(bool isSuccess, string message, T result)
        {
            IsSuccess = isSuccess;
            Message = message;
            Result = result;
        }
    }
}
