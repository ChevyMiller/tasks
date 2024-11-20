using lesson3.Repositories;
using lesson3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace lesson3.Services                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      

{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public List<Tasks> GetAllTasks()
        {
            var allTasks = _taskRepository.GetAllTasks();
            return allTasks;
              
        }
        public void AddTask(Tasks newTask)
        {
            _taskRepository.AddTask(newTask);
        }
        public Tasks GetTaskById(int id)
        {
            return _taskRepository.GetTaskById(id);
        }

        public void UpdateTask(Tasks task)
        {
            _taskRepository.UpdateTask(task);
        }

        public void DeleteTask(int id)
        {
            _taskRepository.DeleteTask(id);
        }
        public DataTable GetTasksByProjectId(int id)
        {
            return _taskRepository.GetTasksByProjectId(id);            

        }


    }
}
