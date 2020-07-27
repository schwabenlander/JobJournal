﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JobJournal.Shared.DTOs
{
    public class CompanyContactDTO
    {
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Guid CompanyId { get; set; }

        [Required(ErrorMessage = "Full Name is required")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [Display(Name = "Title")]
        public string JobTitle { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        [StringLength(15)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email Address is required")]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        [StringLength(128)]
        public string EmailAddress { get; set; }

        public string Comments { get; set; }

        [Display(Name = "First Contact")]
        [DataType(DataType.Date)]
        public DateTime? FirstContactDate { get; set; }

        [Display(Name = "Most Recent Contact")]
        [DataType(DataType.Date)]
        public DateTime? MostRecentContactDate { get; set; }
    }
}
