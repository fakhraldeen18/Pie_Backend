using System.ComponentModel.DataAnnotations;

namespace BackendPieProject.Dtos
{
	public class OrderReadDTO
	{
		public int OrderId { get; set; }
		public string FullName { get; set; }

		[Required]
		public string PhoneNumber { get; set; }
		[Required]
		[StringLength(50)]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }
		[Required]
		public DateTime createAt { get; set; } = DateTime.Now;
		[Required]
		public decimal Total { get; set; }
	}

	public class OrderCreateDTO
	{
		public string FullName { get; set; }

		[Required]
		public string PhoneNumber { get; set; }
		[Required]
		[StringLength(50)]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }
		[Required]
		public DateTime createAt { get; set; } = DateTime.Now;
		[Required]
		public decimal Total { get; set; }
	}
}
