using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public class Company
    {
        [Key]
        public int CompanyId
        {
            get;
            set;
        }

        public string CompanyName
        {
            get;
            set;
        }

        public ICollection<ContactInfo> Contacts
        {
            get;
            set;
        }
    }
}