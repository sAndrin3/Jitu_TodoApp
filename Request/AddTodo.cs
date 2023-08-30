using System.ComponentModel.DataAnnotations;

namespace TodoApp.Requests {
    public class AddTodo{
        [Required]
        public string Title {get; set; } = string.Empty;
        [Required]
        public string Description {get; set; } = string.Empty;
      
    }
}