using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.DataModels.Entities
{
    public class EntityBase
    {
        [Key]
        public int Id { get; set; }
        
        public bool Deleted { get; set; }

        [NotMapped]
        public bool IsNew
        {
            get
            {
                return Id == 0;
            }
        }
    }
}
