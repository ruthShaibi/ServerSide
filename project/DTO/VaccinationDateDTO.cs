using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class VaccinationDateDTO
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int VaccinationId { get; set; }
        public DateTime ReciveDate { get; set; }
        public int Number { get; set; }
    }
}
