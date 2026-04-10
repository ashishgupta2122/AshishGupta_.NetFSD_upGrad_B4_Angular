using System.ComponentModel.DataAnnotations;

namespace ContactManagement.API.Models
{
    public class ContactInfo
    {
        public int ContactId
        {
            get;
            set;
        }

        [Required]
        public string? FirstName
        {
            get;
            set;
        }

        [Required]
        public string? LastName
        {
            get;
            set;
        }

        [Required]
        [EmailAddress]
        public string? EmailId
        {
            get;
            set;
        }

        [Required]
        public long MobileNo
        {
            get;
            set;
        }

        [Required]
        public string? Designation
        {
            get;
            set;
        }

        public int CompanyId
        {
            get;
            set;
        }
        public int DepartmentId
        {
            get;
            set;
        }
    }
}