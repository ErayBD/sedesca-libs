using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceLayer.Models {
    public class MyBooks {
        [Key] public int Id { get; set; }
        public string title { get; set; } = null!;
        public int authorId { get; set; }
        public int genreId { get; set; }
        public int BookId { get; set; }

        public Book Book { get; set; }

        [ForeignKey("authorId")]
        public Author Author { get; set; }

        [ForeignKey("genreId")]
        public Genre Genre { get; set; }
    }
}
