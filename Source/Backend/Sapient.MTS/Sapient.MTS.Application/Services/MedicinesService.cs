using Sapient.MTS.Application.Dtos;
using Sapient.MTS.Application.Helpers;
using Sapient.MTS.Application.Mappers;
using Sapient.MTS.Application.Repositories.Interfaces;
using Sapient.MTS.Application.Services.Interfaces;
using Sapient.MTS.Common.Exceptions;
using System;
using System.Collections.Generic;
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
                .Select(_ => MedicineMapper.ToDto(_)).OrderBy(_ => _.Id);
        }
        public MedicineDto AddMedicine(MedicineDto medicineDto)
        {
            bool isValid = MedicineValidator.IsValid(medicineDto);
            if (!isValid) { throw new ValidationException("Validation for object failed"); }

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


        public MedicineDto UpdateMedicine(MedicineDto medicineDto)
        {
            bool isValid = MedicineValidator.IsValid(medicineDto);
            if (!isValid) { throw new ValidationException("Validation for object failed"); }


            var medicine = MedicineMapper.ToEntity(medicineDto);

            var savedMedicine = _medicinesRepository.GetAll().First(m => m.Id == medicineDto.Id);
            if (savedMedicine == null) { throw new NotFoundException("Medicines", medicineDto.Id); }

            savedMedicine.ModifiedOn = DateTime.Now;
            savedMedicine.FullName = medicineDto.FullName;
            savedMedicine.Brand = medicineDto.Brand;
            savedMedicine.Notes = medicineDto.Notes;
            savedMedicine.Price = medicineDto.Price;
            savedMedicine.Quantity = medicineDto.Quantity;
            savedMedicine.ExpiryDate = medicineDto.ExpiryDate;

            _medicinesRepository.UpdateMedicine(savedMedicine);

            return MedicineMapper.ToDto(savedMedicine);
        }
    }
}
