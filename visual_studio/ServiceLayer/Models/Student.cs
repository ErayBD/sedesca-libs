using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.Models {
	public class Student {
		[Key] public int Id { get; set; }
		public string firstName { get; set; } = null!;
		public string lastName { get; set; } = null!;
		public string email { get; set; } = null!;
		public string phone { get; set; } = null!;
		public string gender { get; set; } = null!;
    }
}
