using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        //constructor class çalıştığı zaman ayrıca this(Result) yazarak aynı zamanda diğer constructor bloğunun da çalışmasını sağlar.
        public Result(bool success, string message):this(success)
        {
            Message = message;
        }

        // overload yaparak mesaj yazmadan sadece true false olarak da döndürebiliriz yada sadece mesaj olarak da yazılabilirdi
        public Result(bool success)
        {
            Success = success;
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
