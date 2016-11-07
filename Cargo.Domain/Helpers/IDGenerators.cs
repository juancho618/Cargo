using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargo.Domain.Helpers
{
    public class IDGenerators
    {
        public string NewId()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
