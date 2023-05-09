using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserService
    {
        DAL.Model.UserModel model=new DAL.Model.UserModel();
        public List<DTO.UserDTO> Get()
        {
            return Convert.UserConvert.Convert(model.Get());
        }
        public DTO.UserDTO GetById(string id)
        {
            return Convert.UserConvert.Convert(model.GetById(id));
        }
        public List<DTO.UserDTO>  GetByMobilePhone(string phone)
        {
            return Convert.UserConvert.Convert(model.GetByMobilePhone(phone));
        }
        public DTO.UserDTO Post(UserDTO userDTO)
        {
            return Convert.UserConvert.Convert(model.Post(Convert.UserConvert.Convert(userDTO)));
        }
        public DTO.UserDTO Put(UserDTO userDTO)
        {
            return Convert.UserConvert.Convert(model.Put(Convert.UserConvert.Convert(userDTO)));
        }
    }
}
