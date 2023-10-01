using System.ComponentModel.DataAnnotations;
using back_end_alpha.Dto;
using back_end_alpha.Models;

namespace back_end_alpha.Interfaces
{
	public interface IEmployeeRepository
	{
		ICollection<Employee> GetEmployees();

		Employee GetEmployeeId(int EmployeeId);

		Employee GetEmployeeByNationalIdentity(String NationalIdentity);

        bool CreateEmployee(String NationalIdentity, String FirstName, String LastName, String PhoneNumber, int Role, DateTime BirthDate, int State, float Salary);

		bool DeleteEmployee(Employee employee);

		bool UpdateEmployee(EmployeeDto updateEmployee);

		bool Save();


    }
}

