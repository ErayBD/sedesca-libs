using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.Models {
	public class Genre {
		[Key] public int Id { get; set; }
		public string genreName { get; set; } = null!;
	}
}
