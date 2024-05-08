using ArithmeticExecuteServices.Models;

namespace ArithmeticExecuteServices.Services.Interfaces
{
    public interface IAuthorizeService
    {
        string AuthorizeFunc(AuthorizeModel loginModel);
    }
}