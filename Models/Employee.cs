using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back_end_alpha.Models
{
	public class Employee
	{


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required(ErrorMessage = "National Identity Required")]
        [StringLength(10,ErrorMessage = " the National Identity must be 10")]
        public string NationalIdentity { get; set;}

        [Required(ErrorMessage = "FirstName is Required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage ="Phone is required")]
        [StringLength(10, MinimumLength = 10,ErrorMessage ="The phone number must be 10")]
        public string PhoneNumber {get; set;}

        public int Role { get; set; } = 0;

        [Required]
        public DateTime BirthDate { get; set;}

       
        [Required]
        public int State { get; set; } = 0;

        [Required]
        public float Salary { get; set;}

      
    }
}

