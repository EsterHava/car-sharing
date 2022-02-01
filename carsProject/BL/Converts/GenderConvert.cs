using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BL.Converts
{
    public static class GenderConvert
    {
        public static GenderDTO ConvertToGenderDTO(gender gender)
        {
            GenderDTO genderDTO = new GenderDTO();
            genderDTO.description = gender.description;
            genderDTO.id = gender.id;
            return genderDTO;
        }
        public static gender ConvertToGender(GenderDTO genderDTO)
        {
            gender gender = new gender();
            gender.description = genderDTO.description;
            gender.id = genderDTO.id;
            return gender;
        }

    }
}
