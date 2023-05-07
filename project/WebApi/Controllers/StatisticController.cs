using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class StatisticController: ApiController
    {
        BLL.StatisticService service= new BLL.StatisticService();

        [HttpGet]

        public DTO.StatisticDTO GetNotVaccinated()
        {
            return new DTO.StatisticDTO()
            {
                notVaccinated = service.GetNotVaccinated(),
                ActivePatientsInLastMonth=service.GetActivePatientsInLastMonth()
            };
        }
    }
}