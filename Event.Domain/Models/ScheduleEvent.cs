using System.ComponentModel.DataAnnotations;

namespace Event.Domain.Models
{
    public class ScheduleEvent
    {
        public int Id { get; set; }

        [Required]
        public string Topic { get; set; }

        public string Details { get; set; }

        public string Speaker { get; set; }

        [Required]
        public string WhereNWnen { get; set; }
    }

}
