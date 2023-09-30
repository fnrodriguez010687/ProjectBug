using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ProjectBug_Entities
{
    public class Bug
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public	int UserId { get; set; }
        public User RelatedUser { get; set; }
        [StringLength(100)]
        public string	Description {  get; set; }
        public DateTime	CreationDate { get; set; }

    }
}
