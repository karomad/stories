using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Stories.WebApp.Models
{
    public class UserViewModel : ViewModelBase
    {
        public UserViewModel()
        {
            Stories = new List<StoryViewModel>();
            Groups = new List<GroupViewModel>();
        }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public IList<StoryViewModel> Stories { get; set; }
        public IList<GroupViewModel> Groups { get; set; }
    }
}