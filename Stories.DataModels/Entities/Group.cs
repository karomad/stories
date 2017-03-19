using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.DataModels.Entities
{
    public class Group : EntityBase
    {
        public Group()
        {
            Stories = new HashSet<Story>();
            Members = new HashSet<User>();
        }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<User> Members { get; set; }
        public virtual ICollection<Story> Stories { get; set; }

        [NotMapped]
        public int MembersCount { get; set; }
        [NotMapped]
        public int StoriesCount { get; set; }
        [NotMapped]
        public bool IsInGroup { get; set; }
    }

    [NotMapped]
    public class GroupForProjection: Group { }
}
