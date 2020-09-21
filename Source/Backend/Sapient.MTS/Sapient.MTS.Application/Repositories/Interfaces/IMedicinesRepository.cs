using Sapient.MTS.Persistence.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sapient.MTS.Application.Repositories.Interfaces
{
    public interface IMedicinesRepository
    {
        IEnumerable<Medicine> GetAll();
        void AddMedicine(Medicine medicine);
        Task<int> UpdateMedicine(Medicine medicine);
        Task<int> DeleteMedicine(Medicine medicine);
    }
}
