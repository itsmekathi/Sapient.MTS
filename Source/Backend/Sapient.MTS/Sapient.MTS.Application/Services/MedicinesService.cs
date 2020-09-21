using Sapient.MTS.Application.Dtos;
using Sapient.MTS.Application.Helpers;
using Sapient.MTS.Application.Mappers;
using Sapient.MTS.Application.Repositories.Interfaces;
using Sapient.MTS.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sapient.MTS.Application.Services
{
    public class MedicinesService : IMedicinesService
    {
        public IMedicinesRepository _medicinesRepository { get; }
        public MedicinesService(IMedicinesRepository medicinesRepository)
        {
            _medicinesRepository = medicinesRepository;

        }
        public IEnumerable<MedicineDto> GetAllMedicines()
        {
            return _medicinesRepository.GetAll()
                .Select(_ => MedicineMapper.ToDto(_));
        }
        public MedicineDto AddMedicine(MedicineDto medicineDto)
        {
            bool isValid = MedicineValidator.IsValid(medicineDto);
            if (!isValid) { throw new ValidationException(); }

            var medicine = MedicineMapper.ToEntity(medicineDto);
            medicine.Id = (_medicinesRepository.GetAll().OrderByDescending(_ => _.Id).FirstOrDefault()?.Id ?? 0) + 1;
            medicine.CreatedOn = DateTime.Now;
            _medicinesRepository.AddMedicine(medicine);

            return MedicineMapper.ToDto(medicine);
        }

        public Task<int> DeleteMedicine()
        {
            throw new System.NotImplementedException();
        }


        public Task<int> UpdateMedicine()
        {
            throw new System.NotImplementedException();
        }
    }
}
