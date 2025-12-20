using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using examinationAPI.Models;
using examinationAPI.ViewModels;

namespace examinationAPI.MiddleWares
{
    public class GlobalErrorHandlerMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                var response = new ResponseViewModel<bool>()
                {
                    IsSuccess = false,
                    errorCode = ErrorCode.InternalServerError,
                    Message = ex.Message,
                };
                await context.Response.WriteAsJsonAsync(response);
            }
        }
    }
}