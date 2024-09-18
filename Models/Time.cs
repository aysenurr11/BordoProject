using System.ComponentModel.DataAnnotations;

namespace BordoProject.Models
{
    public class Time
    {

        [Key]
        public int TimeId { get; set; }

        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public DateTime Day { get; set; }

        public ICollection<Answer> Answers { get; set; }
    }
}
