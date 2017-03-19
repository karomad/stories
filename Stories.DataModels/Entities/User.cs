using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.DataModels.Entities
{
    public class User: EntityBase
    {
        public User()
        {
            Stories = new HashSet<Story>();
            Groups = new HashSet<Group>();
        }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public virtual ICollection<Story> Stories { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
    }
}
