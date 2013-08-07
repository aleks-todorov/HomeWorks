using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBlogSystem.Models
{
    class Category
    {
        private ICollection<Post> posts;

        public Category()
        {
            this.posts = new HashSet<Post>();
        }

        public int CategoryId { get; set; }

        public virtual int Posts
        {
            get { return posts; }
            set { posts = value; }
        }

    }
}
