﻿
namespace Ecommerce_PhuongNam_v1.Application.Common.Exceptions
{
    public class ExceptionDetail : Exception
    {
        public string message { get; set; }
        public object obj { get; set; }

        public ExceptionDetail(string message)
        {
            this.message = message;
        }
        
        public ExceptionDetail(object T)
        {
            this.obj = T;
        }
        public ExceptionDetail(){}

        public ExceptionDetail (string message, Exception detail) :base (message, detail) { }
    }
}
