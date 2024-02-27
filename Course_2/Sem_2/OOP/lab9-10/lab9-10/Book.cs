using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab9
{
    [Table("Books")]
    public class Book
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Author_ID { get; set; }

        [ForeignKey("Author_ID")]
        public virtual Author Author { get; set; }
    }
}