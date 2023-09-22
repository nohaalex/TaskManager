using Microsoft.Data.SqlClient;
using TaskManager.Models;

namespace TaskManager.Data
{
    public class TaskSql:ITask
    {
        private readonly string TaskConnect;

        public TaskSql(IConfiguration configuration)
        {
            TaskConnect = configuration.GetConnectionString("TaskConnect");
        }

        public void Insert(TaskDetails task)
        {
            using (SqlConnection conn = new SqlConnection(TaskConnect))
            {

                conn.Open();
                string InsertQuery = "INSERT INTO TaskTable(TaskName,TaskDescription) VALUES (@TaskName,@TaskDescription)";
                using (SqlCommand command = new SqlCommand(InsertQuery, conn))
                {

                    command.Parameters.AddWithValue("@TaskName", task.TaskName);
                    command.Parameters.AddWithValue("@TaskDescription", task.TaskDescription);
                    
                    command.ExecuteNonQuery();
                }
                conn.Close();
            }
        }


        public void Delete(int TaskId)
        {
            using (SqlConnection conn = new SqlConnection(TaskConnect))
            {
                conn.Open();
                string DeleteQuery = "DELETE FROM TaskTable WHERE TaskId=@TaskId";
                using (SqlCommand command = new SqlCommand(DeleteQuery, conn))
                {

                    command.Parameters.AddWithValue("@TaskId", TaskId);

                    command.ExecuteNonQuery();

                }
                conn.Close();
            }
        }


        public TaskDetails GetByTaskName(string TaskName)
        {
            TaskDetails task = new TaskDetails();
            using (SqlConnection conn = new SqlConnection(TaskConnect))
            {
                conn.Open();
                string SelectQuery = "SELECT * FROM TaskTable WHERE TaskName=@TaskName";
                using (SqlCommand command = new SqlCommand(SelectQuery, conn))
                {
                    command.Parameters.AddWithValue("TaskName", TaskName);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            task.TaskId = reader.GetInt32(0);
                            task.TaskName = reader.IsDBNull(1) ? null : reader.GetString(1);
                            task.TaskDescription = reader.IsDBNull(2) ? null : reader.GetString(2);
                            
                        }
                    }

                }
                conn.Close();
            }
            return task;
        }

        public List<TaskDetails> GetAll()
        {
            List<TaskDetails> task = new List<TaskDetails>();
            using (SqlConnection conn = new SqlConnection(TaskConnect))
            {
                conn.Open();
                string SelectQuery = "SELECT * FROM TaskTable";
                using (SqlCommand command = new SqlCommand(SelectQuery, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            task.Add(new TaskDetails
                            {
                                TaskId = reader.GetInt32(0),
                                TaskName = reader.IsDBNull(1) ? null : reader.GetString(1),
                                TaskDescription = reader.IsDBNull(2) ? null : reader.GetString(2),
                                
                            });
                        }
                    }
                }
                conn.Close();
            }
            return task;
        }

    }
}
