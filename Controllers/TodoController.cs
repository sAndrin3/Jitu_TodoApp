using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Entities;
using TodoApp.Requests;
using TodoApp.ResponseDTO;

namespace TodoApp.Controllers {
    [Route("api/[controller]")]
    [ApiController]

    public class TodoController : ControllerBase {
        
        //Static only one instance
        private static List<Todo> _todos = new List<Todo>(){
            {new Todo(){
                Id=Guid.NewGuid(),
                Title="Todo one",
                Description="Todo one Description",
                EndDate=DateTime.Now.AddDays(1),
            }
        }

    };
    private readonly IMapper _mapper;

    public TodoController(IMapper mapper)
    {
        _mapper = mapper;
    }

    //Get Todos
    [HttpGet]
    public ActionResult<List<TodoResponse>> GetAllTodo(){
        // transformation
        var todos = _mapper.Map<List<TodoResponse>>(_todos);
        return Ok(todos);
    }

       //Get a Todo
    [HttpGet("{id}")]
    public ActionResult<TodoResponse> GetTodo(Guid id){
            try
            {
                // Search
                var existingTodo = _todos.First(x => x.Id == id);
                // transformation
                var todo = _mapper.Map<TodoResponse>(existingTodo);
                return Ok(todo);
            }
            catch (Exception ex)
            {
            
            return BadRequest(ex.Message);
        }
    }
    // Add a Todo
    [HttpPost]
    public ActionResult<TodoSuccess> PostTodo([FromBody]AddTodo todo){
        var newTodo = _mapper.Map<Todo>(todo);
        newTodo.Id = Guid.NewGuid();
        _todos.Add(newTodo);

        return Ok(new TodoSuccess(201, "Todo Created Succesfully"));
    }

        [HttpPut("{id}")]
        public ActionResult<TodoSuccess> UpdateTodo(Guid id, AddTodo updatedTodo)
        {
            var existingTodo = _todos.FirstOrDefault(x => x.Id == id);
            if (existingTodo != null)
            {
                // Update
                // existingTodo.Title = updatedTodo.Title;
                // existingTodo.Description = updatedTodo.Description;
                // return Ok(new TodoSuccess(204, "Todo Updated Succesfully"));

                _mapper.Map(updatedTodo, existingTodo);
                return Ok(new TodoSuccess(204, "Todo Updated Succesfully"));

            }
            return NotFound("Todo Not Found");
        }


        [HttpDelete("{id}")]
        public ActionResult<TodoSuccess> DeleteTodo(Guid id)
        {
            var existingTodo = _todos.FirstOrDefault(x => x.Id == id);
            if (existingTodo != null)
            {
                _todos.Remove(existingTodo);
                return Ok(new TodoSuccess(204, "Todo Deleted Succesfully"));

            }
            return NotFound("Todo Not Found");
        }
    }
}