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
        public IHttpActionResult Get()
        {
            try
            {
                var vac = service.Get();

                return Created("כל החיסונים התקבלו" , vac);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        //פונ' שליפה לפי מזהה
        [Route("~/api/Vaccination/GetById/{id}")]

        public IHttpActionResult Get(int id)
        {
            try
            {
                var vac =service.Get(id);

                return Created("התקבל חיסון לפי מזהה חיסון", vac);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
             
        }

        //פונ' שליפה לפי שם
        [Route("~/api/Vaccination/GetByName/{name}")]
        public IHttpActionResult GetByName(string name)
        {
            try
            {
                var vac = service.GetByName(name);

                return Created("התקבל חיסון לפי שם", vac);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
             
        }

        //פונ' שליפה לפי יצרן
        [Route("~/api/Vaccination/GetByManufacturer/{mfct}")]
        public IHttpActionResult GetByManufacturer(string mfct)
        {
            try
            {
                var vac = service.GetByManufacturer(mfct);

                return Created("התקבל חיסון לפי יצרן", vac);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
             
        }

        // פונ' הוספה
        [HttpPost]
        [Route("~/api/Vaccination/Post")]
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
        public IHttpActionResult Put(VaccinationDTO Vaccination)
        {
            try
            {
                var vac = service.Put(Vaccination);

                return Created("חיסון עודכן", vac);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
             
        }
    }
}