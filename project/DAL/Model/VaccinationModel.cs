using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class VaccinationModel
    {
        public List<Vaccination> Get()

        {
            using (HOMEntities db = new HOMEntities())
            {
                return db.Vaccinations.Where(x => x.Status == 1).ToList();
            }
        }

        public Vaccination Get(int Id)
        {
            using (HOMEntities db = new HOMEntities())
            {
                return db.Vaccinations.FirstOrDefault(x => x.Id == Id && x.Status == 1);
            }
        }
        public Vaccination GetByName(string name)
        {
            using (HOMEntities db = new HOMEntities())
            {
                return db.Vaccinations.FirstOrDefault(x => x.Name == name && x.Status == 1);
            }
        }
        public List<Vaccination> GetByManufacturer(string mfct)
        {
            using (HOMEntities db = new HOMEntities())
            {
                return db.Vaccinations.Where(x => x.Manufacturer.Contains(mfct) && x.Status == 1).ToList();
            }
        }

        public Vaccination Post(Vaccination Vaccination)
        {
            using (HOMEntities db = new HOMEntities())
            {
                Vaccination = db.Vaccinations.Add(Vaccination);
                try
                {
                    db.SaveChanges();
                    return Vaccination;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
        public Vaccination Put(Vaccination vaccination)
        {
            using (HOMEntities db = new HOMEntities())
            {
                Vaccination newVaccination = db.Vaccinations.FirstOrDefault(x => x.Id == vaccination.Id);
                newVaccination.Name = vaccination.Name;
                newVaccination.Manufacturer = vaccination.Manufacturer;
                newVaccination.Status = vaccination.Status;
                try
                {
                    db.SaveChanges();
                    return vaccination;

                }
                catch (Exception e)
                {
                    throw e;
                }

            }

        }
    }
}