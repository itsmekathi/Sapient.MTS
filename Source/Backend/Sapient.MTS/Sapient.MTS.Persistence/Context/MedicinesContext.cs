using Microsoft.Extensions.Configuration;
using Sapient.MTS.Persistence.Entities;
using System.Collections.Generic;

namespace Sapient.MTS.Persistence.Context
{
    public class MedicinesContext: BaseFileDbContext<List<Medicine>>
    {
        private IConfiguration _configuration;
        public MedicinesContext(IConfiguration configuration)
            :base(configuration["JSONFileLocation"])
        {
            _configuration = configuration;
            LoadDataFromFile();
        }

        public virtual List<Medicine> Medicines { get; set; }

        public void LoadDataFromFile()
        {
            Medicines = base.LoadData();
        }
        public void SaveChangesToFile()
        {
            base.SaveChanges(Medicines);
        }
    }
}
