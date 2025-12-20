using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using examinationAPI.Models;

namespace examinationAPI.Exceptions
{
    public class NotFoundException : BaseApplicationException
    {
        public NotFoundException(string message, ErrorCode errorCode) : base(message, errorCode, StatusCodes.Status400BadRequest)
        { }

        public NotFoundException(string message, ErrorCode errorCode, Exception innerException) : base(message, ErrorCode.ValidationError, StatusCodes.Status400BadRequest,innerException)
        { }
    }
}