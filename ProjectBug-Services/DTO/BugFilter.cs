using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBug_Services.DTO
{
    public class BugFilter
    {
        public int? ProjectId { get; set; }
        public int? UserId { get; set; }
        public RangeFilter<DateTime?> CreatedAt { get; set; }
    }
}
