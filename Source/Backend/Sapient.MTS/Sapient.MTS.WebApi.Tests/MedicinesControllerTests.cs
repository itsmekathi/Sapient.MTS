using Moq;
using NUnit.Framework;
using Sapient.MTS.Application.Dtos;
using Sapient.MTS.Application.Services.Interfaces;
using Sapient.MTS.Common.Exceptions;
using Sapient.MTS.WebApi.Controllers;
using System;
using System.Collections.Generic;

namespace Sapient.MTS.WebApi.Tests
{

    public class MedicinesControllerTests
    {
        private Mock<IMedicinesService> _serviceMock;
        private MedicinesController _controller;
        [SetUp]
        public void SetUp()
        {
            _serviceMock = new Mock<IMedicinesService>();
            _controller = new MedicinesController(_serviceMock.Object);
        }

        [Test]
        public void GetAll_WhenCalled_ShouldInvokeServiceMethod()
        {
            _serviceMock.Setup(_ => _.GetAllMedicines()).Returns(new List<MedicineDto>()
            {
                new MedicineDto()
                {
                    FullName = "Medicine-1",
                    Price = 1.0M
                }
            });

            var response = _controller.GetAll();

            Assert.IsNotNull(response);
            _serviceMock.Verify(_ => _.GetAllMedicines(), Times.Once);
        }

        [Test]
        public void AddMedicine_WhenCalled_WithValidData_ShouldReturnProperResponse()
        {
            var medicineDto = new MedicineDto()
            {
                FullName = "Medicine-1",
                Price = 1.0M,
                ExpiryDate = DateTime.Now.AddDays(-1)
            };
            _serviceMock.Setup(_ => _.AddMedicine(It.IsAny<MedicineDto>())).Returns(() => { throw new ValidationException("Invalid data");});

            Assert.Throws<ValidationException>(() => _controller.AddMedicine(medicineDto));

            _serviceMock.Verify(_ => _.AddMedicine(It.IsAny<MedicineDto>()), Times.Once);

        }

        [Test]
        public void AddMedicine_WhenCalledInvalidData_ShouldReturn()
        {
            var medicineDto = new MedicineDto()
            {
                FullName = "Medicine-1",
                Price = 1.0M,
                Brand = "Cipla",
                ExpiryDate = DateTime.Now,
                Notes = "Good Medicine",
                Quantity = 100
            };
            _serviceMock.Setup(_ => _.AddMedicine(It.IsAny<MedicineDto>())).Returns(medicineDto);

            _controller.AddMedicine(medicineDto);

            _serviceMock.Verify(_ => _.AddMedicine(It.IsAny<MedicineDto>()), Times.Once);
        }
    }
}
