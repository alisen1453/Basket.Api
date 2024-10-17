using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Core.Exceptions
{
    public class ExceptionModel:ErrorCode
    {
        public IEnumerable<string> Errors { get; set; }
        public override string ToString()
        {
            return  JsonConvert.SerializeObject(Errors);
        }
    }

    public class ErrorCode {
    public int statuscode {  get; set; }    
    }
}
