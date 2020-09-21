using Sapient.MTS.Application.Dtos;
using Sapient.MTS.Persistence.Entities;

namespace Sapient.MTS.Application.Mappers
{
    public static class MedicineMapper
    {
        public static MedicineDto ToDto(Medicine medicine)
        {
            return new MedicineDto()
            {
                Id = medicine.Id,
                Brand = medicine.Brand,
                ExpiryDate = medicine.ExpiryDate,
                FullName = medicine.FullName,
                Notes = medicine.Notes,
                Price = medicine.Price,
                Quantity = medicine.Quantity
            };
        }

        public static Medicine ToEntity(MedicineDto medicineDto)
        {
            return new Medicine()
            {
                Id = 0,
                FullName = medicineDto.FullName,
                Brand = medicineDto.Brand,
                ExpiryDate = medicineDto.ExpiryDate,
                Notes = medicineDto.Notes,
                Price = medicineDto.Price,
                Quantity = medicineDto.Quantity
            };
        }
    }
}
