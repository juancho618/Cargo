using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cargo.Models;
using Cargo.Helper;
using Microsoft.AspNet.Identity;
using System.IO;
using System.Data.Entity;


namespace Cargo.Controllers
{
    public class EventBlogController : Controller
    {
        private CargoDBEntities db = new CargoDBEntities();
        private ApplicationDbContext us = new ApplicationDbContext();
        // GET: EventBlog
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Post(string id)
        {
            return View(new { id = id });
        }
        
        //Method to post files for every post
        public JsonResult PostFile(HttpPostedFileBase file, string id, string idComment)
        {
            var postId = id;
            var ext = System.IO.Path.GetExtension(file.FileName);
            var name = System.IO.Path.GetFileNameWithoutExtension(file.FileName);
            if (Directory.Exists(Server.MapPath("~/Files/Post/" + postId + "/")) == false)
                Directory.CreateDirectory(Server.MapPath("~/Files/Img/" + postId + "/"));
            string filename = name;
            file.SaveAs(Server.MapPath("~/Files/Img/" + postId + "/") + filename +  ext);

            Comment comment = db.Comments.Find(idComment);
            comment.FileUrl = name + ext;
            db.Entry(comment).State = EntityState.Modified;
            db.SaveChanges();

            var userId = User.Identity.GetUserId();
            var userName = us.Users.Where(x => x.Id == userId).Select(x => x.Nombre).SingleOrDefault();
            var mail = us.Users.Where(x => x.Id == userId).Select(x => x.Email).SingleOrDefault();
            var foto = us.Users.Where(x => x.Id == userId).Select(x => x.Foto).SingleOrDefault();

            var obj = new
            {
                date = comment.Date,
                message = comment.CommentMessage,
                user = userName,
                mail = mail,
                foto = foto,
                url = comment.FileUrl 
            };

            return Json(new {data= obj }, JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult GetPost(string id)
        {
            var post = from q in db.Posts
                       where q.PostID == id
                       select new
                       {
                           title=q.Title
                       };
            var publications = from q in db.Comments
                               join u in db.AspNetUsers on q.Fk_User equals u.Id
                               where q.Fk_Post == id
                               orderby q.Date ascending
                               select new
                               {
                                   date = q.Date,
                                   message = q.CommentMessage,
                                   user = u.Nombre.Trim(),
                                   mail=u.UserName.Trim(),
                                   foto=u.Foto,
                                   url = q.FileUrl
                               };

            return Json(new { data = post.SingleOrDefault(), list = publications.ToList() }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllPost()
        {
            var userId = User.Identity.GetUserId();

            var list = from q in db.Posts
                       join u in db.PostUsers on q.PostID equals u.Fk_Post
                       where u.Fk_User == userId
                       orderby q.PubDate descending
                       select new
                       {
                           id=q.PostID,
                           title=q.Title,
                           description=q.Description,
                           date=q.PubDate
                       };

            /*
             use this later for admin validation
              var list = from q in db.Posts
                       orderby q.PubDate descending
                       select new
                       {
                           id=q.PostID,
                           title=q.Title,
                           description=q.Description,
                           date=q.PubDate
                       };   
             */

            return Json(new { data = list.ToList() }, JsonRequestBehavior.AllowGet);
        }

        /*revisar!!*/
        public JsonResult PostMessage(Comment comment,string url, string id)
        {
            var userId=User.Identity.GetUserId();
            var userName = us.Users.Where(x => x.Id == userId).Select(x => x.Nombre).SingleOrDefault();

            GenerateId generator = new GenerateId();

            comment.CommentId = generator.generateID();
            comment.Fk_Post = id;
            comment.Fk_User = userId;
            comment.Date = DateTime.Now;
            if (comment.CommentMessage != null) { 
                db.Comments.Add(comment);
                db.SaveChanges();
            }
            var mail= us.Users.Where(x => x.Id == userId).Select(x => x.Email).SingleOrDefault();
            var foto = us.Users.Where(x => x.Id == userId).Select(x => x.Foto).SingleOrDefault();
            var obj = new
            {
                date=comment.Date,
                message=comment.CommentMessage,
                user=userName,
                mail = mail,
                foto = foto,
                url = url
            };

            return Json(new {data=obj, postId=comment.CommentId }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult CreatePost(Post postEntry)
        {
            GenerateId generator = new GenerateId();
            var userId = User.Identity.GetUserId();

            postEntry.PostID = generator.generateID();
            postEntry.PubDate = DateTime.Now;
            db.Posts.Add(postEntry);
            db.SaveChanges();


            CreateUserPost(postEntry.PostID, userId);

            var post = new
            {
                title = postEntry.Title,
                description= postEntry.Description,
                date = postEntry.PubDate,
            };
            return Json(new {data=post }, JsonRequestBehavior.AllowGet);
        }

        public void CreateUserPost(String PostId, String UserId)
        {
            GenerateId generator = new GenerateId();

            PostUser postRelation = new PostUser();

            postRelation.PostUserID = generator.generateID();
            postRelation.Fk_Post = PostId;
            postRelation.Fk_User = UserId;
            db.PostUsers.Add(postRelation);
            db.SaveChanges();
        }


    }
}