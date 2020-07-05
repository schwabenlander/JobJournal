using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JobJournal.Shared.DTOs
{
    public class CompanyDTO
    {
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        [Display(Name = "Company Name")]
        [StringLength(50)]
        public string CompanyName { get; set; }

        [Required]
        [Display(Name = "Website Address")]
        [DataType(DataType.Url)]
        [StringLength(128)]
        public string WebsiteURI { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        [StringLength(15)]
        public string PhoneNumber { get; set; }

        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        [StringLength(128)]
        public string EmailAddress { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(2)]
        [Display(Name = "State")]
        public string State { get; set; }
    }
}
