using System;
using System.ComponentModel.DataAnnotations;
namespace VaccinatorNet.Models
{
    public class Vaccine
    {

        [Key]
        public int VaccineId { get; set; }

        public string Brand { get; set; }

        public string VaccineType { get; set; }

        public DateTime ExpirationDate { get; set; }

        public int ValidityPeriod { get; set; }
    }
}
