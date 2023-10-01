using back_end_alpha.Data;
using back_end_alpha.Dto;
using back_end_alpha.Interfaces;
using back_end_alpha.Models;

namespace back_end_alpha.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _context;
		public EmployeeRepository(DataContext context)
		{
			_context = context;
		}

        public bool CreateEmployee(string NationalIdentity, string FirstName, string LastName, string PhoneNumber, int Role, DateTime BirthDate, int State, float Salary)
        {
          
                var Employee = new Employee()
                {
                    NationalIdentity = NationalIdentity,
                    FirstName = FirstName,
                    LastName = LastName,
                    PhoneNumber = PhoneNumber,
                    Role = Role,
                    BirthDate = BirthDate,
                    State = State,
                    Salary = Salary
                };
                _context.Add(Employee);
                
                return Save();

         
            
             
        }

       

        public bool DeleteEmployee(Employee employee)
        {
            employee.State = -1;

            _context.Update(employee);

            return Save();
        }

        public Employee GetEmployeeByNationalIdentity(string NationalIdentity)
        {
            return _context.Employees.Where(e => e.NationalIdentity.Equals(NationalIdentity)).FirstOrDefault();
        }

        public Employee GetEmployeeId(int EmployeeId)
        {
            return _context.Employees.Where(e => e.Id == EmployeeId).FirstOrDefault();
          
        }

        public ICollection<Employee> GetEmployees()
		{
			return _context.Employees.OrderBy(e => e.Id).ToList();
		}

        public bool Save()
        {
            var saved = _context.SaveChanges();

            return saved > 0;
        }

        public bool UpdateEmployee(EmployeeDto updateEmployee)
        {
            throw new NotImplementedException();
        }
    }
}

