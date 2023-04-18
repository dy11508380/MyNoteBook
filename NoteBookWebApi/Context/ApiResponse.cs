namespace NoteBookWebApi.Context
{
    public class ApiResponse
    {
        public ApiResponse(string message, bool status = false)
        {
            this.Status = status;
            this.Message = message;
        }

        public ApiResponse(bool status, object result)
        {
            this.Status = status;
            this.Result = result;
        }
        public string Message { get; set; }

        public bool Status { get; set; }

        public object Result { get; set; }
    }
}
