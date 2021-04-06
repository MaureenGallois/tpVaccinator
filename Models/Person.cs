using System;
using System.ComponentModel.DataAnnotations;
namespace VaccinatorNet.Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }

        public string Lastname { get; set; }

        public string Firstname { get; set; }

        public DateTime BirthDate { get; set; }

        public string Sex { get; set; }

        public bool IsResident { get; set; }
    }
}
