using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using examinationAPI.Models;

namespace examinationAPI.ViewModels
{
    public class SuccessResponseViewModel<T> : ResponseViewModel<T>
    {
        public SuccessResponseViewModel(T data)
        {
            Data = data;
            IsSuccess = true;
            errorCode = ErrorCode.NoError;
            Message = "Operation Completed Successfully";
        }
    }
}