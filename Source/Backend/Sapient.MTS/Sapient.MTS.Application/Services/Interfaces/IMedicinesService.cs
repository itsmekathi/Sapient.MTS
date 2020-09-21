using Sapient.MTS.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sapient.MTS.Application.Services.Interfaces
{
    public interface IMedicinesService
    {
        IEnumerable<MedicineDto> GetAllMedicines();
        MedicineDto AddMedicine(MedicineDto medicineDto);
        Task<int> UpdateMedicine();
        Task<int> DeleteMedicine();
    }
}
