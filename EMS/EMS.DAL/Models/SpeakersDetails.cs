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
        }

        [Required, StringLength(50)]
        public string SpeakerName
        {
            get;
            set;
        }
    }
}