namespace back_end_alpha.Dto
{
	public class EmployeeDto
	{

        public string NationalIdentity { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public int Role { get; set; } = 0;

        public DateTime BirthDate { get; set; }


        public int State { get; set; } = 0;

        public float Salary { get; set; }
    }
}

