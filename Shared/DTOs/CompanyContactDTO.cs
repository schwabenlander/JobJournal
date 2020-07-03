﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JobJournal.Shared.DTOs
{
    public class CompanyContactDTO
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public CompanyDTO Company { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        [StringLength(15)]
        public string PhoneNumber { get; set; }

        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        [StringLength(128)]
        public string EmailAddress { get; set; }

        [Display(Name = "First Contact")]
        [DataType(DataType.Date)]
        public DateTime? FirstContactDate { get; set; }

        [Display(Name = "Most Recent Contact")]
        [DataType(DataType.Date)]
        public DateTime? MostRecentContactDate { get; set; }
    }
}
