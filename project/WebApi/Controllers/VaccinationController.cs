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
        public DTO.VaccinationDTO Get(int id)
        {
            return service.Get(id);
        }
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
    }
}