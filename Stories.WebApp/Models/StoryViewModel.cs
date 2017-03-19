using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Stories.WebApp.Models
{
    public class StoryViewModel : ViewModelBase
    {
        public StoryViewModel()
        {
            Groups = new List<GroupViewModel>();
        }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public DateTime PostedOn { get; set; }
        public int UserId { get; set; }
        public string User { get; set; }
        public IList<GroupViewModel> Groups { get; set; }
    }
}