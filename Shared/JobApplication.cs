using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JobJournal.Shared
{
    public class JobApplication
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }

        public Company Company { get; set; }
        
        [Required]
        public Guid CompanyId { get; set; }

        [Required]
        public string JobTitle { get; set; }

        [Required]
        public DateTime ApplicationDate { get; set; }

        public ApplicationStatus ApplicationStatus { get; set; }

        public ApplicationMethod ApplicationMethod { get; set; }
    }

    public enum ApplicationStatus
    {
        Applied = 1,
        Interviewing = 2,
        Rejected = 3,
        Declined = 4,
        Hired = 5
    }

    public enum ApplicationMethod
    {
        DirectOnline = 1,
        DirectEmail = 2,
        DirectInPerson = 3,
        Recruiter = 4,
        Friend = 5,
        Indeed = 6,
        LinkedIn = 7,
        StackOverflow = 8,
        Other = 9
    }
}
