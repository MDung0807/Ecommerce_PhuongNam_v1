using BusBookTicket.Core.Common.Exceptions;

namespace Ecommerce_PhuongNam_v1.Application.Common.Exceptions
{
    public class AuthException : ExceptionDetail
    {
        public AuthException(string message) : base(message) { }
    }
}
