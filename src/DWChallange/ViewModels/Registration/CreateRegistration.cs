using System.ComponentModel.DataAnnotations;

namespace DWChallange.ViewModels.Registration
{
    public class CreateRegistration
    {

        [Required]
        public int EventId { get; set; }

        [Required, StringLength(256)]
        public string? Name { get; set; }

        [Required, StringLength(32)]
        public string? PhoneNumber { get; set; }


        [Required, StringLength(256)]
        public string? EmailAddress { get; set; }


    }
}
