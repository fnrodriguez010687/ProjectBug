using ProjectBug_Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBug_Services.DTO
{
    public class BugOutputList
    {
        public List<BugOutput> Bugs { get; set; }
    }
}
