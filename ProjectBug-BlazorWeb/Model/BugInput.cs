
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBug_BlazorWeb.Model
{
    public class BugInput
    {
        public int Project { get; set; }
        public int User { get; set; }
        public string Description { get; set; }
    }
}
