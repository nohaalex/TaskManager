using TaskManager.Models;

namespace TaskManager.Data
{
    public interface ITask
    {
        void Insert(TaskDetails task);

        void Delete(int TaskId);

        TaskDetails GetByTaskName(string TaskName);

        List<TaskDetails> GetAll();
        
    }
}
