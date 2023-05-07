using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class VaccinationDateModel
    {
        public List<VaccinationDate> Get()

        {
            using (HOMEntities db = new HOMEntities())
            {
                return db.VaccinationDates.ToList();
            }
        }
        public VaccinationDate GetByUserId(string Id)
        {
            using (HOMEntities db = new HOMEntities())
            {
                return db.VaccinationDates.FirstOrDefault(x => x.UserId == Id);
            }
        }
        public VaccinationDate GetByVaccinationId(string Id)
        {
            using (HOMEntities db = new HOMEntities())
            {
                return db.VaccinationDates.FirstOrDefault(x => x.VaccinationId == int.Parse(Id));
            }
        }
        public bool IsValidNumber(int number, string id)
        {
            using (HOMEntities db = new HOMEntities())

            {
                if (number > 4)
                    return false;
                if (db.VaccinationDates.Where(x => x.UserId == id).Any(x => x.Number > number))
                    return false; else return true;

            }
        }
        public bool IsValidUserAndVacId(string UserId, int VacId)
        {
            using (HOMEntities db = new HOMEntities())
            {
                return db.users.Any(x => x.Id == UserId) && db.Vaccinations.Any(x => x.Id == VacId);
            }
        }
        public bool IsValidDate(DateTime date)
        {
            return date<= DateTime.Now;    
        }

        public bool Validation(VaccinationDate VaccinationDate)
        {
            return IsValidDate(VaccinationDate.ReciveDate) && IsValidUserAndVacId(VaccinationDate.UserId, VaccinationDate.VaccinationId) &&
                IsValidNumber((int)VaccinationDate.Number,VaccinationDate.UserId);
        }
        public VaccinationDate Post(VaccinationDate VaccinationDate)
        {
            using (HOMEntities db = new HOMEntities())
            {
                if (!Validation(VaccinationDate))
                    return null;
                db.SaveChanges();
                return VaccinationDate;
            }
        }
    }
}
