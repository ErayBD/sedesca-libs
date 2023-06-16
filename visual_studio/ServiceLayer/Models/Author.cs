using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.Models {
	public class Author {
		[Key] public int Id { get; set; }
		public string authorName { get; set; } = null!;

    }

	
}

