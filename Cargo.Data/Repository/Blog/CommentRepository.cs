using Cargo.Data.Entities;
using Cargo.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargo.Data.Repository.Blog
{
    public class CommentRepository
    {
        IDGenerators IDGenerator = new IDGenerators();

        public IEnumerable<Comment> GetCommentsByPostId(string id)
        {
            using (CargoDBEntities db = new CargoDBEntities())
            {
                return (from q in db.Comment
                        //join u in db.AspNetUsers on q.Fk_User equals u.Id
                        where q.Fk_Post == id && !q.Deleted && q.Active
                        orderby q.Date ascending
                        select q).ToList();
            }
        }
    }
}
