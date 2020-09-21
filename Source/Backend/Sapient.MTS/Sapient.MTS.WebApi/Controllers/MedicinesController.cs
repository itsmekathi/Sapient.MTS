using Microsoft.AspNetCore.Mvc;
using Sapient.MTS.Application.Dtos;
using Sapient.MTS.Application.Services.Interfaces;
using System.Collections.Generic;

namespace Sapient.MTS.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class MedicinesController: ControllerBase
    {
        private IMedicinesService _medicineService;
        public MedicinesController(IMedicinesService medicinesService)
        {
            _medicineService = medicinesService;
        }
        [HttpGet]
        public IEnumerable<MedicineDto> GetAll()
        {
            return _medicineService.GetAllMedicines();
        }

        [HttpPost]
        public IActionResult AddMedicine([FromBody]MedicineDto medicineDto)
        {
            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);

            return Ok(_medicineService.AddMedicine(medicineDto));
        }

    }
}
