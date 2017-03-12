using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyFast.Application.Common.Dto
{
    public class EasyUIGridOutput<T>
    {
        public long total { get; set; }

        public IEnumerable<T> rows { get; set; }
    }
}
