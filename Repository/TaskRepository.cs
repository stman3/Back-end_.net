using back_end_alpha.Data;
using back_end_alpha.Interfaces;


namespace back_end_alpha.Repository
{
	public class TaskRepository : ITaskRepository
    {

        private readonly DataContext _context;
		public TaskRepository(DataContext context)
		{
            _context = context;
		}

        public int CreateTask(string Title, int ClientId, int EmployeeId)
        {
            var clinet = _context.Clients.Where(c => c.Id == ClientId).FirstOrDefault();
            var employee = _context.Employees.Where(e => e.Id == EmployeeId).FirstOrDefault();
            if (clinet == null)
                return  500;

            if (employee == null)
                return 501;

            var task = new Models.Task()
            {
                Title = Title,
                ClientId = ClientId,
                EmployeeId = EmployeeId,

            };

            _context.Add(task);
            Save();

            return 200;
        }

        public bool DeleteTask(Models.Task task)
        {
            task.State = -1;

            _context.Update(task);

            return Save();
        }

        public Models.Task GetTaskById(int TaskId)
        {
            return _context.Tasks.Where(t => t.Id == TaskId).FirstOrDefault();
        }

        public ICollection<Models.Task> GetTasks()
        {
            return _context.Tasks.OrderBy(t => t.Id).ToList();
        }

        public ICollection<Models.Task> GetTasksByClientId(int ClientId)
        {
            return _context.Tasks.Where(t => t.ClientId == ClientId).ToList();
        }

        public ICollection<Models.Task> GetTasksByEmployeeId(int EmployeeId)
        {
            return _context.Tasks.Where(t => t.EmployeeId == EmployeeId).ToList();
        }

        public ICollection<Models.Task> GetTasksDone()
        {
            return _context.Tasks.Where(t => t.State == 1).ToList();
        }

        public ICollection<Models.Task> GetTasksNotDone()
        {
            return _context.Tasks.Where(t => t.State == 0).ToList();
        }

        public bool UpdateTaskState(Models.Task task)
        {
            task.State = 1;

            _context.Update(task);

            return Save();
        }

        public bool Save()
        {
            var save = _context.SaveChanges();

            return save > 0;
        }


    }
}

