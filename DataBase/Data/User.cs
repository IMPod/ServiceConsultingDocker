﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataBase.Data
{
    public class User : BaseRecord
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string SecondName { get; set; }

        public string MiddleName { get; set; }

        [Required]
        public DateTime BirthDay { get; set; }

        [Required]
        public string Sex { get; set; }

        [Required]
        [StringLength(11, ErrorMessage = "СНИЛС должен быть длинной 11 символов вместе с контрольной суммой", MinimumLength = 11)]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Некорректный СНИЛС")]
        public string Snils { get; set; }

        public List<Consultation> Consultations { get; set; }
    }
}
