using BusBookTicket.Core.Common.Exceptions;
using FluentValidation.Results;

namespace Ecommerce_PhuongNam_v1.Application.Common.Exceptions;

public class ValidatorException : ExceptionDetail
{
    public List<string> Errors { get; private set; }
    public ValidatorException(List<ValidationFailure> errors)
    {
        Errors = new List<string>();
        foreach (var item in errors)
        {
            Errors.Add(item.PropertyName + " "+ item.ErrorMessage);
        }
    }
    
    public ValidatorException(string message): base(message)
    {
    }
  
}