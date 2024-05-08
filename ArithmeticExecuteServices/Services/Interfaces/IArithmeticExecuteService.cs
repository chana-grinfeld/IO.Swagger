using IO.Swagger.Models;

namespace ArithmeticExecuteServices.Services.Interfaces
{
    public interface IArithmeticExecuteService
    {
        //חתימת הפונקציות 
        public int ArithmeticExecute(ArithmeticExecuteModel request, string operationRequest);
        public int Add(int num1, int num2);
        public int Subtract(int num1, int num2);
        public int Multiply(int num1, int num2);
        public int Divide(int num1, int num2);
    }
}