using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class StatisticService
    {
        DAL.Model.StatisticModel model= new DAL.Model.StatisticModel();
         public int GetNotVaccinated()
        {
            return model.GetNotVaccinated();
        }
        public Dictionary<int,int> GetActivePatientsInLastMonth()
        {
            return model.GetActivePatientsInLastMonth();
        }
    }
}
