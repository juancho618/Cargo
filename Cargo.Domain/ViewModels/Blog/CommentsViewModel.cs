using Cargo.Domain.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargo.Domain.ViewModels.Blog
{
    class CommentsViewModel
    {
        public string Id { get; set; }        
        public DateTime Date { get; set; }
        public string Message { get; set; }
        public String FileUrl { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
        public PostViewModel Post { get; set; }
        public UserViewModel User { get; set; }
    }
}
