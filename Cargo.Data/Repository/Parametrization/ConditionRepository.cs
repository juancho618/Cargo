using Cargo.Data.Entities;
using Cargo.Domain.Helpers;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Cargo.Data.Repository.Parametrization
{
    public class ConditionRepository
    {
        IDGenerators IDGenerator = new IDGenerators();

        public IEnumerable<Condition> GetAll()
        {
            using (CargoDBEntities db = new CargoDBEntities())
            {
                return (from q in db.Condition
                        orderby q.ConditionName
                        select q).ToList();
            }
        }

        public Condition GetCountryById(string id)
        {
            using (CargoDBEntities db = new CargoDBEntities())
            {
                return (from q in db.Condition
                        orderby q.ConditionID == id
                        select q).SingleOrDefault();
            }
        }

        public string Save(Condition condition)
        {
            using (CargoDBEntities db = new CargoDBEntities())
            {
                condition.ConditionID = IDGenerator.NewId();
                db.Condition.Add(condition);
                db.SaveChanges();

                return country.CountryID;
            }
        }

        public Country Edit(Country country)
        {
            using (CargoDBEntities db = new CargoDBEntities())
            {
                db.Entry(country).State = EntityState.Modified;
                db.SaveChanges();

                return country;
            }
        }

        public Country ToggleState(Country country)
        {
            using (CargoDBEntities db = new CargoDBEntities())
            {
                if (country.Active == true)
                    country.Active = false;
                else
                    country.Active = true;

                db.Entry(country).State = EntityState.Modified;
                db.SaveChanges();

                return country;
            }
        }

        public Country Delete(Country country)
        {
            using (CargoDBEntities db = new CargoDBEntities())
            {
                country.Deleted = !country.Deleted;
                db.Entry(country).State = EntityState.Modified;
                db.SaveChanges();

                return country;
            }
        }
    }
}
