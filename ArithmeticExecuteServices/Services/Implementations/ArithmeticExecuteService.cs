using ArithmeticExecuteServices.Services.Interfaces;
using IO.Swagger.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using FromBodyAttribute = Microsoft.AspNetCore.Mvc.FromBodyAttribute;

namespace ArithmeticExecuteServices.Services.Implementations
{
    public class ArithmeticExecuteService : IArithmeticExecuteService
    {
        //my business logic
        public int ArithmeticExecute([FromBody] ArithmeticExecuteModel request, [FromHeader][Required()] string operationRequest)
        {
            int num1 = request.Number1;
            int num2 = request.Number2;
            string operation = operationRequest;

            switch (operation)
            {
                case "Add":
                    return Add(num1, num2);
                case "Subtract":
                    if (num1 < num2)
                    {
                        throw new ArgumentException("Subtraction result would be negative.");
                    }
                    return Subtract(num1, num2);
                case "Multiply":
                    return Multiply(num1, num2);
                case "Divide":
                    if (num2 == 0)
                    {
                        throw new DivideByZeroException("Cannot divide by zero.");
                    }
                    return Divide(num1, num2);
                default:
                    throw new ArgumentException("Invalid operator provided.");
            }

        }
        public int Add(int num1, int num2)
        {
            return Convert.ToInt32(num1 + num2);
        }
        public int Subtract(int num1, int num2)
        {
            return Convert.ToInt32(num1 - num2);
        }
        public int Multiply(int num1, int num2)
        {
            return Convert.ToInt32(num1 * num2);
        }
        public int Divide(int num1, int num2)
        {
            if (num2 == 0)
            {
                throw new ArgumentException("Cannot divide by zero.");
            }
            return num1 / num2;
        }
    }
}