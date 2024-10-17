using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Core.Exceptions
{
    public class BaseNotFoundException : Exception
    {
        public BaseNotFoundException(string? message) : base(message)
        {
        }
    }
}
