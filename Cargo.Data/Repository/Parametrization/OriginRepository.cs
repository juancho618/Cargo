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
    public class OriginRepository
    {
        IDGenerators IDGenerator = new IDGenerators();

        public IEnumerable<Origin> GetAll()
        {
            using (CargoDBEntities db = new CargoDBEntities())
            {
                return (from q in db.Origin
                        orderby q.OriginName
                        select q).ToList();
            }
        }

        public Origin GetOriginById(string id)
        {
            using (CargoDBEntities db = new CargoDBEntities())
            {
                return (from q in db.Origin
                        orderby q.OriginId == id
                        select q).SingleOrDefault();
            }
        }

        public string Save(Origin origin)
        {
            using (CargoDBEntities db = new CargoDBEntities())
            {
                origin.OriginId = IDGenerator.NewId();
                db.Origin.Add(origin);
                db.SaveChanges();

                return origin.OriginId;
            }
        }

        public Origin Edit(Origin origin)
        {
            using (CargoDBEntities db = new CargoDBEntities())
            {
                db.Entry(origin).State = EntityState.Modified;
                db.SaveChanges();

                return origin;
            }
        }

        public Origin ToggleState(Origin origin)
        {
            using (CargoDBEntities db = new CargoDBEntities())
            {
                if (origin.Active == true)
                    origin.Active = false;
                else
                    origin.Active = true;

                db.Entry(origin).State = EntityState.Modified;
                db.SaveChanges();

                return origin;
            }
        }

        public Origin Delete(Origin origin)
        {
            using (CargoDBEntities db = new CargoDBEntities())
            {
                origin.Deleted = !origin.Deleted;
                db.Entry(origin).State = EntityState.Modified;
                db.SaveChanges();

                return origin;
            }
        }
    }
}
