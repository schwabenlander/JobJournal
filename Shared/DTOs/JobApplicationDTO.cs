using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JobJournal.Shared.DTOs
{
    public class JobApplicationDTO
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public Company Company { get; set; }

        [Required]
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }

        [Required]
        [Display(Name = "Date of Application")]
        [DataType(DataType.Date)]
        public DateTime ApplicationDate { get; set; }

        [Display(Name = "First Method")]
        [Range(1, 9)]
        public int ApplicationMethod { get; set; }

        [Display(Name = "Application Status")]
        [Range(1, 5)]
        public int ApplicationStatus { get; set; }
    }
}
