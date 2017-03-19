using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Stories.WebApp.Models
{
    public class GroupViewModel : ViewModelBase
    {
        public GroupViewModel()
        {
            Members = new List<UserViewModel>();
            Stories = new List<StoryViewModel>();
        }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<UserViewModel> Members { get; set; }
        public IList<StoryViewModel> Stories { get; set; }
        public int MembersCount { get; set; }
        public int StoriesCount { get; set; }
        public bool IsInGroup { get; set; }
    }
}