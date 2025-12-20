using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using examinationAPI.Models;

namespace examinationAPI.Exceptions
{
    public class BusinessLogicException : BaseApplicationException
    {
        public BusinessLogicException(string message, ErrorCode errorCode) : base(message, errorCode, StatusCodes.Status400BadRequest)
        {
        }
        
        public BusinessLogicException(string message, ErrorCode errorCode,Exception innerException) : base(message, errorCode,StatusCodes.Status400BadRequest, innerException)
        {}
    }
}