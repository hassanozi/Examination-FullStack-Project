using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                Stopwatch stopwatch = Stopwatch.StartNew();
                await next(context);
                stopwatch.Stop();

                if (stopwatch.ElapsedMilliseconds > 1000)
                {
                    Console.WriteLine($"Request {context.Request.Path} processed in {stopwatch.ElapsedMilliseconds} ms");
                }
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