using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using examinationAPI.Models;

namespace examinationAPI.Exceptions
{
    public class BaseApplicationException : Exception
    {

        public ErrorCode ErrorCode { get; set; }
        public int HttpStatusCode { get; set; }

        protected BaseApplicationException(string message, ErrorCode errorCode, int httpStatusCode)
        {
            ErrorCode = errorCode;
            HttpStatusCode = httpStatusCode;
        }

        protected BaseApplicationException(string message, ErrorCode errorCode,int httpStatusCode,Exception innerException):base(message, innerException)
        {
            ErrorCode = errorCode;
            HttpStatusCode = httpStatusCode;
        }
    }
}