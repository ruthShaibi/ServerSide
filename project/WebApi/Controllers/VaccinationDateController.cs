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
        public List<DTO.VaccinationDateDTO> Get()
        {
            return service.Get();
        }
        //שליפה לפי ת.ז
        [Route("~/api/VaccinationDate/GetByUserId/{id}")]
        public List<DTO.VaccinationDateDTO> GetByUserId(string id)
        {
            return service.GetByUserId(id);
        }
        //שליפה לפי מזהה חיסון
        [Route("~/api/VaccinationDate/GetByVaccinationId/{id}")]
        public List<DTO.VaccinationDateDTO> GetByVaccinationId(int id)
        {
            return service.GetByVaccinationId(id);
        }
        //הוספה
        [HttpPost]
        public IHttpActionResult Post(VaccinationDateDTO VaccinationDateDTO)
        {
            try
            {
                var vacDate = service.Post(VaccinationDateDTO);

                return Created(" מועד החיסון התווסף", vacDate);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //עידכון
        [HttpPut]
        public DTO.VaccinationDateDTO Put(VaccinationDateDTO VaccinationDateDTO)
        {
            return service.Put(VaccinationDateDTO);
        }
    }
}