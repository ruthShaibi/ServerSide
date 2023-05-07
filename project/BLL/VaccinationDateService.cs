using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class VaccinationDateService
    {
        DAL.Model.VaccinationDateModel model = new DAL.Model.VaccinationDateModel();

        public List<DTO.VaccinationDateDTO> Get()
        {
            return Convert.VaccinationDateConvert.Convert(model.Get());
        }
        public DTO.VaccinationDateDTO GetByUserId(string id)
        {
            return Convert.VaccinationDateConvert.Convert(model.GetByUserId(id));
        }
        public DTO.VaccinationDateDTO GetByVaccinationId(string id)
        {
            return Convert.VaccinationDateConvert.Convert(model.GetByVaccinationId(id));
        }
        public DTO.VaccinationDateDTO Post(VaccinationDateDTO VaccinationDateDTO)
        {
            return Convert.VaccinationDateConvert.Convert(model.Post(Convert.VaccinationDateConvert.Convert(VaccinationDateDTO)));
        }
    }
}
