using Sapient.MTS.Application.Repositories.Interfaces;
using Sapient.MTS.Persistence.Context;
using Sapient.MTS.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sapient.MTS.Application.Repositories
{
    public class MedicinesRepository : IMedicinesRepository
    {
        public MedicinesContext _medicinesContext { get; }
        public MedicinesRepository(MedicinesContext medicinesContext)
        {
            _medicinesContext = medicinesContext;
        }

        public void AddMedicine(Medicine medicine)
        {
            _medicinesContext.Medicines.Add(medicine);
            _medicinesContext.SaveChangesToFile();
        }

        public IEnumerable<Medicine> GetAll()
        {
            return _medicinesContext.Medicines;
        }
        public Task<int> DeleteMedicine(Medicine medicine)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateMedicine(Medicine medicine)
        {
            throw new NotImplementedException();
        }
    }
}
