using AutoMapper;
using TodoApp.Entities;
using TodoApp.Requests;
using TodoApp.ResponseDTO;


namespace TodoApp.TodoProfiles{

    public class TodoProfiles : Profile {
        public TodoProfiles()
        {
            CreateMap<Todo, TodoResponse>().ReverseMap();
            CreateMap<Todo, AddTodo>().ReverseMap();
        }
    }
}