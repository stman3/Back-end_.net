using back_end_alpha.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back_end_alpha.Dto
{
    public class TaskDto
	{
		


            public string Title { get; set; }




            public int ClientId { get; set; } 

            [Required]
            public int EmployeeId { get; set; }







    }

}

