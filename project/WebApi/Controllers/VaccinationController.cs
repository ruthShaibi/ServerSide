using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class VaccinationController:ApiController
    {
        BLL.VaccinationService service = new BLL.VaccinationService();
        [HttpGet]
        public List<DTO.VaccinationDTO> Get()
        {
            return service.Get();
        }
        //פונ' שליפה לפי מזהה
        public DTO.VaccinationDTO Get(int id)
        {
            return service.Get(id);
        }

        //פונ' שליפה לפי שם
        [Route("~/api/Vaccination/GetByName/{name}")]
        public DTO.VaccinationDTO GetByName(string name)
        {
            return service.GetByName(name);
        }

        //פונ' שליפה לפי יצרן
        [Route("~/api/Vaccination/GetByManufacturer/{mfct}")]
        public List<DTO.VaccinationDTO> GetByManufacturer(string mfct)
        {
            return service.GetByManufacturer(mfct);
        }

        // פונ' הוספה
        [HttpPost]
        public IHttpActionResult Post(VaccinationDTO VaccinationDTO)
        {
            try
            {
                var vac = service.Post(VaccinationDTO);

                return Created(" החיסון התווסף", vac);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //פןנ' זו מעדכנת חיסון וגם מוחקת ע"י שינוי סטטוס ל0
        [HttpPut]
        [Route("~/api/Vaccination/Put")]
        public DTO.VaccinationDTO Put(VaccinationDTO Vaccination)
        {
            return service.Put(Vaccination);
        }
    }
}