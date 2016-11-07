using Cargo.Data.Entities;
using Cargo.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargo.Data.Repository.Parametrization
{
    public class NotificationRepository
    {
        IDGenerators IDGenerator = new IDGenerators();

        public IEnumerable<Notification> GetAll()
        {
            using (CargoDBEntities db = new CargoDBEntities())
            {
                return (from q in db.Notification
                        orderby q.NotificationName
                        select q).ToList();
            }
        }

        public Notification GetNotificationById(string id)
        {
            using (CargoDBEntities db = new CargoDBEntities())
            {
                return (from q in db.Notification
                        orderby q.NotificationID == id
                        select q).SingleOrDefault();
            }
        }

        public string Save(Notification notification)
        {
            using (CargoDBEntities db = new CargoDBEntities())
            {
                notification.NotificationID = IDGenerator.NewId();
                db.Notification.Add(notification);
                db.SaveChanges();

                return notification.NotificationID;
            }
        }

        public Notification Edit(Notification notification)
        {
            using (CargoDBEntities db = new CargoDBEntities())
            {
                db.Entry(notification).State = EntityState.Modified;
                db.SaveChanges();

                return notification;
            }
        }

        public Notification ToggleState(Notification notification)
        {
            using (CargoDBEntities db = new CargoDBEntities())
            {
                if (notification.Activate == true)
                    notification.Activate = false;
                else
                    notification.Activate = true;

                db.Entry(notification).State = EntityState.Modified;
                db.SaveChanges();

                return notification;
            }
        }

        public Notification Delete(Notification notification)
        {
            using (CargoDBEntities db = new CargoDBEntities())
            {
                notification.Deleted = !notification.Deleted;
                db.Entry(notification).State = EntityState.Modified;
                db.SaveChanges();

                return notification;
            }
        }
    }
}
