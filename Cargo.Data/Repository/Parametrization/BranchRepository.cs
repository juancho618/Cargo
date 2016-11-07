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
    public class BranchRepository
    {
        IDGenerators IDGenerator = new IDGenerators();

        public IEnumerable<Branch> GetAll()
        {
            using (CargoDBEntities db = new CargoDBEntities())
            {
                return (from q in db.Branch
                        orderby q.BranchName
                        select q).ToList();
            }
        }

        public Branch GetBranchById(string id)
        {
            using (CargoDBEntities db = new CargoDBEntities())
            {
                return (from q in db.Branch
                        orderby q.BranchID == id
                        select q).SingleOrDefault();
            }
        }

        public string Save(Branch branch)
        {
            using (CargoDBEntities db = new CargoDBEntities())
            {
                branch.BranchID = IDGenerator.NewId();
                db.Branch.Add(branch);
                db.SaveChanges();

                return branch.BranchID;
            }
        }

        public Branch Edit(Branch branch)
        {
            using (CargoDBEntities db = new CargoDBEntities())
            {
                db.Entry(branch).State = EntityState.Modified;
                db.SaveChanges();

                return branch;
            }
        }

        public Branch ToggleState(Branch branch)
        {
            using (CargoDBEntities db = new CargoDBEntities())
            {
                if (branch.Active == true)
                    branch.Active = false;
                else
                    branch.Active = true;

                db.Entry(branch).State = EntityState.Modified;
                db.SaveChanges();

                return branch;
            }
        }

        public Branch Delete(Branch branch)
        {
            using (CargoDBEntities db = new CargoDBEntities())
            {
                branch.Deleted = !branch.Deleted;
                db.Entry(branch).State = EntityState.Modified;
                db.SaveChanges();

                return branch;
            }
        }
    }
}
