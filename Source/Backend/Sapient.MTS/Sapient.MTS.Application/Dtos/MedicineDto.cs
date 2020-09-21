using System;
using System.ComponentModel.DataAnnotations;

namespace Sapient.MTS.Application.Dtos
{
    public class MedicineDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(1000)]
        public string FullName { get; set; }
        [Required]
        [StringLength(200)]
        public string Brand { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public DateTime ExpiryDate { get; set; }
        [StringLength(200)]
        public string Notes { get; set; }
    }
}
