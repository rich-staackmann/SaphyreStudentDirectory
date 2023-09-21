using System.ComponentModel.DataAnnotations;

namespace SaphyreStudentDirectory.Client.ViewModels
{
    /*
     * The main point of a view model or DTO is to hide unnecessary data from the client. 
     * This could also be sensitive data. Here this is just an example of using
     * this style from me.
     */
    public class StudentVM
    {
        public int ID { get; set; }

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
