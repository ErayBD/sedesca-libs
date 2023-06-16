using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceLayer.Models {
	public class StudentBook {
		[Key] public int Id { get; set; }
		public int studentId { get; set; }
		public int bookId { get; set; }

    }
}
