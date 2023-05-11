using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class VaccinationDateController:ApiController
    {

        BLL.VaccinationDateService service = new BLL.VaccinationDateService();
        //שליפה
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                var vacDate = service.Get();

                return Created("התקבלו כל ביצועי החיסונים", vacDate);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
             
        }
        //שליפה לפי ת.ז
        [Route("~/api/VaccinationDate/GetByUserId/{id}")]
        public IHttpActionResult GetByUserId(string id)
        {
            try
            {
                var vacDate = service.GetByUserId(id);

                return Created("ביצוע חיסון לפי ת.ז מבוטח", vacDate);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
             
        }
        //שליפה לפי מזהה חיסון
        [Route("~/api/VaccinationDate/GetByVaccinationId/{id}")]
        public IHttpActionResult GetByVaccinationId(int id)
        {
            try
            {
                var vacDate =service.GetByVaccinationId(id);

                return Created("התקבלו ביצועי חיסונים לםי מזהה חיסון", vacDate);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
             
        }
        //הוספה
        [HttpPost]
        public IHttpActionResult Post(VaccinationDateDTO VaccinationDateDTO)
        {
            try
            {
                var vacDate = service.Post(VaccinationDateDTO);

                return Created(" ביצוע החיסון התווסף", vacDate);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //עידכון
        [HttpPut]
        public IHttpActionResult Put(VaccinationDateDTO VaccinationDateDTO)
        {
            try
            {
                var vacDate = service.Put(VaccinationDateDTO);

                return Created("ביצוע חיסון עודכן", vacDate);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
             
        }
    }
}