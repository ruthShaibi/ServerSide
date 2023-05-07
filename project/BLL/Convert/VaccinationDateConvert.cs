using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Convert
{
    public class VaccinationDateConvert
    {

        public static DTO.VaccinationDateDTO Convert(DAL.VaccinationDate obj)
        {
            if (obj == null)
            {
                return null;
            }
            return new DTO.VaccinationDateDTO()
            {
                Id = obj.Id,
                UserId=obj.UserId,
                VaccinationId= obj.VaccinationId,
                ReciveDate= obj.ReciveDate,
                Number=(int)obj.Number,
            };

        }

        public static DAL.VaccinationDate Convert(DTO.VaccinationDateDTO obj)
        {
            if (obj == null)
            {
                return null;
            }
            return new DAL.VaccinationDate()
            {
                Id = obj.Id,
                UserId = obj.UserId,
                VaccinationId = obj.VaccinationId,
                ReciveDate = obj.ReciveDate,
                Number = (int)obj.Number,
            };
        }

        public static List<DAL.VaccinationDate> Convert(List<DTO.VaccinationDateDTO> obj)
        {
            return obj.Select(x => Convert(x)).ToList();
        }
        public static List<DTO.VaccinationDateDTO> Convert(List<DAL.VaccinationDate> obj)
        {
            return obj.Select(x => Convert(x)).ToList();
        }
    }
}
