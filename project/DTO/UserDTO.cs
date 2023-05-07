using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime Birth_Date { get; set; }
        public string Phone { get; set; }
        public string Mobile_Phone { get; set; }
        public DateTime PositiveResultDate { get; set; }
        public DateTime CureDate { get; set; }
        public int Status { get; set; }
    }
}
