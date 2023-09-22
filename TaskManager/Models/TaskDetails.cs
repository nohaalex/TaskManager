using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models
{
    public class TaskDetails
    {
        public int TaskId { get; set; }

        [Required(ErrorMessage ="Please enter the type of Task")]
        [DataType(DataType.Text)]
        public string TaskName { get; set; }

        [Required(ErrorMessage ="Please enter the Task")]
        [DataType(DataType.Text)]
        public string TaskDescription { get; set; }

        
    }
}
