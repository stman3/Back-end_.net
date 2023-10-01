using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace back_end_alpha.Models
{
	public class Client
	{

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "National Identity Required")]
        [StringLength(10, ErrorMessage = " the National Identity must be 10")]
        public string NationalIdentity { get; set; }

        [Required(ErrorMessage = "FirstName is Required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        [StringLength(10, ErrorMessage = "The phone number must be 10")]
        public string PhoneNumber { get; set; }

        [Required]
        public int State { get; set; } = 0;

        public string? Note { get; set; }

        [Required]
        public int EmployeeId { get; set; }



        [Required]
        [ForeignKey("EmployeeId")]
        [JsonIgnore] 
        public Employee Employee { get; set; }


    }
}

