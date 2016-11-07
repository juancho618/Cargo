using Cargo.Data.Entities;
using Cargo.Domain.Helpers;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Cargo.Data.Repository.Parametrization
{
    public class UnitTypeRepository
    {
        IDGenerators IDGenerator = new IDGenerators();

        public IEnumerable<UnitType> GetAll()
        {
            using (CargoDBEntities db = new CargoDBEntities())
            {
                return (from q in db.UnitType
                        orderby q.UnitName
                        select q).ToList();
            }
        }

        public string Save(UnitType unitType)
        {
            using (CargoDBEntities db = new CargoDBEntities())
            {
                unitType.UnitTypeId = IDGenerator.NewId();
                db.UnitType.Add(unitType);
                db.SaveChanges();

                return unitType.UnitTypeId;
            }
        }

        public UnitType Edit(UnitType unitType)
        {
            using (CargoDBEntities db = new CargoDBEntities())
            {
                db.Entry(unitType).State = EntityState.Modified;
                db.SaveChanges();

                return unitType;
            }
        }
    }
}
