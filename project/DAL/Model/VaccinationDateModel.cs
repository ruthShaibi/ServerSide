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
        public List<VaccinationDate> GetByUserId(string Id)
        {
            using (HOMEntities db = new HOMEntities())
            {
                return db.VaccinationDates.Where(x => x.UserId == Id).ToList();
            }
        }
        public List<VaccinationDate> GetByVaccinationId(int Id)
        {
            using (HOMEntities db = new HOMEntities())
            {

                return db.VaccinationDates.Where(x => x.VaccinationId == Id).ToList();
            }
        }
        public bool IsValidNumber(int number, string id)
        {
            using (HOMEntities db = new HOMEntities())

            {
                if (number > 4)
                    return false;

                List<VaccinationDate> list = db.VaccinationDates.Where(x => x.UserId == id).ToList();

                if (list.Count()!=0)
                {
                    if (list.Any(x => x.Number >= number))
                        return false;
                    if (list.Max(x => x.Number) == number - 1)
                        return true;
                    else return false;
                }               
                 return true;

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
            return date <= DateTime.Now;
        }

        public bool Validation(VaccinationDate VaccinationDate)
        {
            return IsValidDate(VaccinationDate.ReciveDate) && IsValidUserAndVacId(VaccinationDate.UserId, VaccinationDate.VaccinationId) &&
                IsValidNumber((int)VaccinationDate.Number, VaccinationDate.UserId);
        }
        public VaccinationDate Post(VaccinationDate VaccinationDate)
        {
            using (HOMEntities db = new HOMEntities())
            {
                if (!Validation(VaccinationDate))
                    return null;
                VaccinationDate = db.VaccinationDates.Add(VaccinationDate);
                try
                {
                    db.SaveChanges();
                    return VaccinationDate;
                }
                catch (Exception e)
                {
                    throw e;
                }

            }
        }
        public VaccinationDate Put(VaccinationDate VaccinationDate)
        {
            using (HOMEntities db = new HOMEntities())
            {
                VaccinationDate newVaccinationDate = db.VaccinationDates.FirstOrDefault(x => x.Id == VaccinationDate.Id );
                newVaccinationDate.VaccinationId = VaccinationDate.VaccinationId;
                newVaccinationDate.ReciveDate = VaccinationDate.ReciveDate;
                newVaccinationDate.Number = VaccinationDate.Number;

                if (!Validation(newVaccinationDate)) return null;
                try
                {
                    db.SaveChanges();
                    return VaccinationDate;
                }
                catch (Exception e)
                {
                    throw e;
                }

            }

        }
    }
}
