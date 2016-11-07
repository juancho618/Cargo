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
    public class CountryRepository
    {
        IDGenerators IDGenerator = new IDGenerators();

        public IEnumerable<Country> GetAll()
        {
            using (CargoDBEntities db = new CargoDBEntities())
            {
                return (from q in db.Country
                        orderby q.CountryName
                        select q).ToList();
            }
        }

        public Country GetCountryById(string id)
        {
            using (CargoDBEntities db = new CargoDBEntities())
            {
                return (from q in db.Country
                        orderby q.CountryID == id
                        select q).SingleOrDefault();
            }
        }

        public string Save(Country country)
        {
            using (CargoDBEntities db = new CargoDBEntities())
            {
                country.CountryID = IDGenerator.NewId();
                db.Country.Add(country);
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
