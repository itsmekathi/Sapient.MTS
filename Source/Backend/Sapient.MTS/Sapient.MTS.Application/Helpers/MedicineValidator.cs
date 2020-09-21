using Sapient.MTS.Application.Dtos;
using System;

namespace Sapient.MTS.Application.Helpers
{
    public static class MedicineValidator
    {
        public static bool IsValid(MedicineDto dto)
        {
            bool result = false;

            if(dto.ExpiryDate >= DateTime.Now)
            {
                result = true;
            }
            return result;
        }
    }
}
