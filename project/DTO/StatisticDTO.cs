using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class StatisticDTO
    {
        public int notVaccinated { get; set; }
        public Dictionary<int, int> ActivePatientsInLastMonth { get; set; }
    }
}
