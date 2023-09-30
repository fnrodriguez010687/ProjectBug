using ProjectBug_Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBug_Services.DTO
{
    public class BugOutput
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Project { get; set; }
        public string Username { get; set; }
        
        public DateTime CreationDate { get; set; }
    }
}
