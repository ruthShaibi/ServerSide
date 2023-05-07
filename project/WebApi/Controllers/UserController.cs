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
        [HttpGet]
        [Route("~/api/user/GetUser")]
        public List<DTO.UserDTO> Get()
        {
            return service.Get();
        }
        public DTO.UserDTO Get(string id)
        {
            return service.Get(id);
        }
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
    }
}