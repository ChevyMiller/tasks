using lesson3.Models;
using System.Text.Json;
using System;
using Microsoft.Data.SqlClient;
using System.Data;

namespace lesson3.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TasksDbContext _context;
        string Cnn;
        public TaskRepository(TasksDbContext context, IConfiguration configuration)
        {
            _context = context;
            Cnn = configuration.GetConnectionString("DefaultConnection");
        }
    


        public void AddTask(Tasks task)
        {
            var allProjects = GetAllProjects();
            Projects? p= allProjects.FirstOrDefault(e => e.Id == task.ProjectId);
            if (p != null) 
            { 
            _context.Tasks.Add(task);
            }
            _context.SaveChanges();

        }

        public void DeleteTask(int id)
        {
            Tasks? task = _context.Tasks.Find(id);

            if (task != null)
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
            }

        }

        public List<Tasks> GetAllTasks()
        {
            return _context.Tasks.ToList();
        }
        public List<Projects> GetAllProjects()
        {
            return _context.Projects.ToList();
        }
     

        public Tasks GetTaskById(int id)
        {
            Tasks? task = _context.Tasks.Find(id);
            return task;
        }

        public void UpdateTask(Tasks task)
        {
            _context.Tasks.Update(task);
            _context.SaveChanges();
        }

        //public List<Tasks> GetTasksByProjectId(int id)
        //{
        //    var tasks = GetAllTasks();
        //    var tasksByProjectId = tasks.Where(e => e.ProjectId == id).ToList();
        //    return tasksByProjectId;

        //}

        public DataTable GetTasksByProjectId(int @ProjectId)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(Cnn))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    //commandtype
                    command.CommandText = "GetTasksByProjectId";
                    command.CommandType = CommandType.StoredProcedure;

                    //paramters
                    SqlParameter sqlParameter = new SqlParameter("@ProjectId", @ProjectId);

                    command.Parameters.Add(sqlParameter);

                    connection.Open();

                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    { 
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }
    }
}
