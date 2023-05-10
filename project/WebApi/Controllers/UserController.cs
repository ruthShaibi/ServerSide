using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class UserController:ApiController
    {
        BLL.UserService service= new BLL.UserService();
        //פונ' שליפה
        [HttpGet]
       [Route("~/api/user/GetUser")]
        public List<DTO.UserDTO> Get()
        {
            return service.Get();
        }
        
        //שליפה לפי ת.ז
        [Route("~/api/user/GetById/{id}")]
        public DTO.UserDTO GetById(string id)
        {
            return service.GetById(id);
        }

        //שליפה לפי טלפון נייד
        [Route("~/api/user/GetByMobilePhone/{phone}")]
        public List<DTO.UserDTO> GetByMobilePhone(string phone)
        {
            return service.GetByMobilePhone(phone);
        }

        //הוספה
        [HttpPost]
        public IHttpActionResult Post(UserDTO userDTO)
        {
            try
            {
                var user = service.Post(userDTO);

                return Created(" הלקוח התווסף", user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        //עדכון ומחיקה ע"י שינוי סטטוס ל0
        [HttpPut]

        [Route("~/api/user/Put")]
        public DTO.UserDTO Put(UserDTO user)
        {
            return service.Put(user);
        }
    }
}