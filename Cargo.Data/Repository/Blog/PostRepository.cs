using Cargo.Data.Entities;
using Cargo.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargo.Data.Repository.Blog
{
    public class PostRepository
    {
        IDGenerators IDGenerator = new IDGenerators();

        public IEnumerable<Post> GetAll(string userId)
        {
            using (CargoDBEntities db = new CargoDBEntities())
            {
                return (from q in db.Post
                        join u in db.PostUser on q.PostID equals u.Fk_Post
                        where u.Fk_User == userId
                        orderby q.PubDate descending
                        select q).ToList();
            }
        }

        public string Create(Post post)
        {
            using (CargoDBEntities db = new CargoDBEntities())
            {
                post.PostID = IDGenerator.NewId();
                post.PubDate = DateTime.Now;
                db.Post.Add(post);

                db.SaveChanges();

                return post.PostID;
            }
        }


    }
}
