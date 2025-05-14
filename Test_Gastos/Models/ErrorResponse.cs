using System.Collections;

namespace Test_Gastos.Models
{
    public class ErrorResponse
    {
        public int Faults { get; set; }
        public string Message { get; set; }
        public IDictionary Data { get; set; }
        public ErrorResponse(string message)
        {
            Faults = 1;
            Message = message;            
        }

        public ErrorResponse(Exception exception)
        {
            Faults = 1;
            Message = exception.Message;
            Data = exception.Data;
        }
    }
}
