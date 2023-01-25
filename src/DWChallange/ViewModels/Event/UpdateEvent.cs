using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DWChallange.ViewModels.Event
{
    public class UpdateEvent
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? Location { get; set; }

        [DisplayName("Start Time")]
        public DateTime StartTime { get; set; }

        [DisplayName("End Time")]
        public DateTime EndTime { get; set; }

    }

}
