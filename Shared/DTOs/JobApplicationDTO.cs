using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JobJournal.Shared.DTOs
{
    public class JobApplicationDTO
    {
        public Guid Id { get; set; }

        public Company Company { get; set; }

        [Required]
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }

        [Required]
        [Display(Name = "Date of Application")]
        [DataType(DataType.Date)]
        public DateTime ApplicationDate { get; set; }

        [Display(Name = "First Method")]
        public int ApplicationMethod { get; set; }

        [Display(Name = "Application Status")]
        public int ApplicationStatus { get; set; }
    }
}
