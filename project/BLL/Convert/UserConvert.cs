using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Convert
{
    public class UserConvert
    {
        public static DTO.UserDTO Convert(DAL.user obj)
        {
            if (obj == null) 
            {
            return null;   
            }
            return new DTO.UserDTO()
            {
                Id = obj.Id,
                Name = obj.Name,
                Address = obj.Address,
                Birth_Date = obj.Birth_Date,
                Phone = obj.Phone,
                Mobile_Phone = obj.Mobile_Phone,
                PositiveResultDate = (DateTime)obj.PositiveResultDate,
                CureDate = (DateTime)obj.CureDate,
                Status=(int)obj.Status,
            };

        } 

        public static DAL.user Convert(DTO.UserDTO obj)
        {
            if(obj == null) 
            {
            return null;
            }
            return new DAL.user()
            {
                Id = obj.Id,
                Name = obj.Name,
                Address = obj.Address,
                Birth_Date = obj.Birth_Date,
                Phone = obj.Phone,
                Mobile_Phone = obj.Mobile_Phone,
                PositiveResultDate = obj.PositiveResultDate,
                CureDate = obj.CureDate,
                 Status = (int)obj.Status,
            };
        }

        public static List<DAL.user> Convert(List<DTO.UserDTO> obj)
        {
            return obj.Select(x => Convert(x)).ToList();
        }
        public static List<DTO.UserDTO> Convert(List<DAL.user> obj)
        {
            return obj.Select(x => Convert(x)).ToList();
        }
    }
}
