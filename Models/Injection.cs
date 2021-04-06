using System;
using System.ComponentModel.DataAnnotations;
namespace VaccinatorNet.Models
{
    public class Injection
    {
        [Key]
        public int VaccinationId { get; set; }

        public Person Person { get; set; }

        public Vaccine Vaccine { get; set; }

        public DateTime InjectionDate { get; set; }

        public string Lot { get; set; }

        public DateTime ReminderDate { get; set; }
    }
}
