using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Convert
{
    public class VaccinationConvert
    {

        public static DTO.VaccinationDTO Convert(DAL.Vaccination obj)
        {
            if (obj == null)
            {
                return null;
            }
            return new DTO.VaccinationDTO()
            {
                Id = obj.Id,
                Name = obj.Name,
                Manufacturer= obj.Manufacturer,
            };

        }

        public static DAL.Vaccination Convert(DTO.VaccinationDTO obj)
        {
            if (obj == null)
            {
                return null;
            }
            return new DAL.Vaccination()
            {
                Id = obj.Id,
                Name = obj.Name,
                Manufacturer = obj.Manufacturer
            };
        }

        public static List<DAL.Vaccination> Convert(List<DTO.VaccinationDTO> obj)
        {
            return obj.Select(x => Convert(x)).ToList();
        }
        public static List<DTO.VaccinationDTO> Convert(List<DAL.Vaccination> obj)
        {
            return obj.Select(x => Convert(x)).ToList();
        }
    }
}
