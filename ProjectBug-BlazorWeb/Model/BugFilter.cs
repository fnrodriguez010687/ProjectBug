using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBug_BlazorWeb.Model
{
    public class BugFilter
    {
        public int? project_id { get; set; }
        public int? user_id { get; set; }
        public DateTime? start_date { get; set; }
        public DateTime? end_date { get; set; }
  }
}
