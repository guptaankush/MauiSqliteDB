using System.ComponentModel.DataAnnotations;

namespace MauiSqliteDB.Models
{
    public class StudentDT
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        public string? Class { get; set; }
    }
}
