using System.ComponentModel.DataAnnotations;

namespace EMS.DAL.Models
{
    public class SpeakersDetails
    {
        [Key]
        public Guid SpeakerId
        {
            get;
            set;
        } = Guid.NewGuid();

        [Required]
        public string SpeakerName
        {
            get;
            set;
        }

        public string? Topic
        {
            get;
            set;
        }
    }
}