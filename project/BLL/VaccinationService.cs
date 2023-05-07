﻿using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class VaccinationService
    {
        DAL.Model.VaccinationModel model = new DAL.Model.VaccinationModel();

        public List<DTO.VaccinationDTO> Get()
        {
            return Convert.VaccinationConvert.Convert(model.Get());
        }
        public DTO.VaccinationDTO Get(int id)
        {
            return Convert.VaccinationConvert.Convert(model.Get(id));
        }
        public DTO.VaccinationDTO Post(VaccinationDTO VaccinationDTO)
        {
            return Convert.VaccinationConvert.Convert(model.Post(Convert.VaccinationConvert.Convert(VaccinationDTO)));
        }
    }
}
