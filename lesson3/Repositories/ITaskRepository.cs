using lesson3.Models;
using System.Data;

namespace lesson3.Repositories
{
    public interface ITaskRepository
    {
        List<Tasks> GetAllTasks();
        Tasks GetTaskById(int id);
        void AddTask(Tasks task);
        void UpdateTask(Tasks task);
        void DeleteTask(int id);
        DataTable GetTasksByProjectId(int id);
    }
}
