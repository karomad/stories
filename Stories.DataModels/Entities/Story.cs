using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.DataModels.Entities
{
    public class Story: EntityBase
    {
        public Story()
        {
            Groups = new HashSet<Group>();
        }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public DateTime PostedOn { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
    }
}
