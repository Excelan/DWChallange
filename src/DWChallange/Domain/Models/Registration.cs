using System.ComponentModel.DataAnnotations;

namespace DWChallange.Domain.Models
{
	public class Registration
	{
		public int Id { get; set; }

		[Required]
		public Event? Event { get; set; }

		[Required, StringLength(256)]
		public string? Name { get; set; }

		[Required, StringLength(32)]
		public string? PhoneNumber { get; set; }


		[Required, StringLength(256)]
		public string? EmailAddress { get; set; }


	}
}
