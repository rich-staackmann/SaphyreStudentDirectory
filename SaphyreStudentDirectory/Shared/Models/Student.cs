using System.ComponentModel.DataAnnotations;

namespace SaphyreStudentDirectory.Domain.Models
{
    public class Student : Entity
    {
        [Required, MaxLength(100)]
        public required string Name { get; set; }

        [Required, MaxLength(100)]
        public required string Address1 { get; set; }

        [MaxLength(100)]
        public string? Address2 { get; set; }

        [Required, MaxLength(50)]
        public required string City { get; set; }

        [Required, MaxLength(20)]
        public required string State { get; set; }

        [Required, DataType(DataType.PhoneNumber)]
        public required string PhoneNumber { get; set; }

        [Range(1, 999, ErrorMessage = "Please enter a value bigger than 1 and less than 999")]
        public int Age { get; set; }
    }
}
