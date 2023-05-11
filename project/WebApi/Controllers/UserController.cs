using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Security.Policy;
using System.Web;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class UserController : ApiController
    {
        BLL.UserService service = new BLL.UserService();
        //פונ' שליפה

        [HttpGet]
        [Route("~/api/user/Get")]
        public IHttpActionResult Get()
        {
            try
            {
                var x = service.Get();
                return Created("כל המשתמשים התקבלו", x);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        //שליפה לפי ת.ז
        [Route("~/api/user/GetById/{id}")]
        public IHttpActionResult GetById(string id)
        {
            try
            {
                var x = service.GetById(id);
                return Created("התקבל משתמש לפי ת.ז", x);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        //שליפה לפי טלפון נייד
        [Route("~/api/user/GetByMobilePhone/{phone}")]
        public IHttpActionResult GetByMobilePhone(string phone)
        {
            try
            {
                var x = service.GetByMobilePhone(phone);
                return Created("התקבל משתמש לפי טלפון נייד", x);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


        }

        //הוספה
        [HttpPost]
        [Route("~/api/user/Post")]

        public IHttpActionResult Post(UserDTO userDTO)
        {

            try
            {

                var x = service.Post(userDTO);
                return Created(" הלקוח התווסף", x);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


        }
        //עדכון ומחיקה ע"י שינוי סטטוס ל0
        [HttpPut]

        [Route("~/api/user/Put")]
        public IHttpActionResult Put(UserDTO user)
        {
            try
            {
                var x = service.Put(user);
                return Created("משתמש עודכן", x);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}