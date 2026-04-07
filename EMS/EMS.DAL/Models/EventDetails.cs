using System.ComponentModel.DataAnnotations;

namespace EMS.DAL.Models
{
    public class EventDetails
    {
        [Key]
        public Guid EventId
        {
            get;
            set;
        }

        [Required, StringLength(50)]
        public string EventName
        {
            get;
            set;
        }

        [Required]
        public string EventCategory
        {
            get;
            set;
        }

        [Required]
        public DateTime EventDate
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public string Status
        {
            get;
            set;
        }
    }
}