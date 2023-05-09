using System;
using System.Collections.Generic;
using System.Linq;
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
                return db.Vaccinations.ToList();
            }
        }
        public Vaccination Get(int Id)
        {
            using (HOMEntities db = new HOMEntities())
            {
                return db.Vaccinations.FirstOrDefault(x => x.Id == Id);
            }
        }
        public Vaccination GetByName(string name)
        {
            using (HOMEntities db = new HOMEntities())
            {
                return db.Vaccinations.FirstOrDefault(x => x.Name == name);
            }
        }
        public List<Vaccination> GetByManufacturer(string mfct)
        {
            using (HOMEntities db = new HOMEntities())
            {
                return db.Vaccinations.Where(x => x.Manufacturer == mfct).ToList();
            }
        }
        public bool IsExist(string name)
        {
            using (HOMEntities db = new HOMEntities())
            {
                return db.Vaccinations.Any(x => x.Name == name);
            }
        }
        public Vaccination Post(Vaccination Vaccination)
        {
            using (HOMEntities db = new HOMEntities())
            {
                if (IsExist(Vaccination.Name))
                    return null;
                Vaccination = db.Vaccinations.Add(Vaccination);
                db.SaveChanges();
                return Vaccination;
            }
        }

    }
}
