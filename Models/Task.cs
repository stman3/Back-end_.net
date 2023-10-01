using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace back_end_alpha.Models
{
	public class Task
	{

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

		[Required]
		public string Title { get; set; }



        [Required]
        public int ClientId { get; set; }  // Assuming you have a property like this

        [Required]
        public int EmployeeId { get; set; }

      
        [Required]
        public int State { get; set; } = 0;



        public DateTime TaskDate { get; set; } = DateTime.Now;


        [Required]
        [ForeignKey("ClientId")]
        [JsonIgnore]
        public Client Client { get; set; }

        [Required]
        [ForeignKey("EmployeeId")]
        [JsonIgnore]
        public Employee Employee { get; set; }



    }
}

