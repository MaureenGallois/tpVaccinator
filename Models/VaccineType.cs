using System;
using System.ComponentModel.DataAnnotations;
namespace VaccinatorNet.Models
{
    public class VaccineType
    {
        [Key]
        public int VaccineTypeId { get; set; }

        public string Name { get; set; }
    }
}
