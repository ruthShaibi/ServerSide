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
        public DTO.UserDTO Get(string id)
        {
            return Convert.UserConvert.Convert(model.Get(id));
        }
        public DTO.UserDTO Post(UserDTO userDTO)
        {
            return Convert.UserConvert.Convert(model.Post(Convert.UserConvert.Convert(userDTO)));
        }
    }
}
