using System;
using System.ComponentModel.DataAnnotations;

namespace DataBase.Data
{
    public class Consultation : BaseRecord
    {
        /// <summary>
        /// Симптомы пациента
        /// </summary>
        public string PatientSymptoms { get; set; }

        public User User { get; set; }
    }
}
