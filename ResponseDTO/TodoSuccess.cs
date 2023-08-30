namespace TodoApp.ResponseDTO{
    public class TodoSuccess{

        public int Code {get; set; }
        public string Message {get; set; } = string.Empty;
        public TodoSuccess(int code, string message)
        {
            this.Message = message;
            this.Code = code;
        }

    }
}