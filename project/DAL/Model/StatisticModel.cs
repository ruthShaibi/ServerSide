using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class StatisticModel
    {
        public int GetNotVaccinated()
        {
            using (HOMEntities db= new HOMEntities())
            {
                int count = 0;
                List <user> users = new List <user> ();
                users=db.users.ToList ();
                foreach (user user in users) {
                    if (db.VaccinationDates.FirstOrDefault(x => x.UserId == user.Id) != null)
                        count++;
                }
                return count;
            }
        }

        public Dictionary<int,int> GetActivePatientsInLastMonth()
        {
            Dictionary<int,int> dict=new Dictionary<int,int>();
            using (HOMEntities db = new HOMEntities())
            {
                
                int curMonth = DateTime.Now.Month;
               int DayInCurrentMonth= DateTime.DaysInMonth(DateTime.Now.Year,curMonth);
                for (int i = 0; i < DayInCurrentMonth; i++)
                {
                    dict[i] = db.users.Where(x => x.PositiveResultDate.Value.Month == curMonth && x.PositiveResultDate.Value.Day == i).Count();
                }
            }
            return dict;

        }
    }
}
