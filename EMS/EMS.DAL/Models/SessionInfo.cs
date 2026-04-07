using System.ComponentModel.DataAnnotations;

namespace EMS.DAL.Models
{
    public class SessionInfo
    {
        [Key]
        public Guid SessionId
        {
            get;
            set;
        }

        public string? SessionTitle
        {
            get;
            set;
        }

        public Guid EventId
        {
            get;
            set;
        }
        public EventDetails? Event
        {
            get;
            set;
        }

        public Guid? SpeakerId
        {
            get;
            set;
        }
        public SpeakersDetails? Speaker
        {
            get;
            set;
        }

        public string? Description
        {
            get;
            set;
        }

        public DateTime SessionStart
        {
            get;
            set;
        }
        public DateTime SessionEnd
        {
            get;
            set;
        }

        public string? SessionUrl
        {
            get;
            set;
        }
    }
}