using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBug_Services.DTO
{
    public class RangeFilter<T>
    {
        public T From { get; set; }
        public T To { get; set; }
    }
}
