using Task = back_end_alpha.Models.Task;

namespace back_end_alpha.Interfaces
{
	public interface ITaskRepository
	{
		ICollection<Task> GetTasks();

		Task GetTaskById(int TaskId);

		bool UpdateTaskState(Task task);

		ICollection<Task> GetTasksByClientId(int ClientId);

		ICollection<Task> GetTasksByEmployeeId(int EmployeeId);

		ICollection<Task> GetTasksDone();

		ICollection<Task> GetTasksNotDone();

        int CreateTask(String Title,int ClientId,int EmployeeId);

		bool DeleteTask(Task task);

        bool Save();
    }
}

