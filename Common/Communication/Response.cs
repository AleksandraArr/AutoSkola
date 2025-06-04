using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Communication
{
    public class Response
    {
        public Boolean IsSuccess { get; set; }
        public object Data { get; set; }
        public string ExceptionMessage { get; set; }
    }
}
