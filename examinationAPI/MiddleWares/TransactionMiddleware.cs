using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using examinationAPI.Data;

namespace examinationAPI.MiddleWares
{
    public class TransactionMiddleware(Context _context) : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                _context.Database.BeginTransaction();
                await next(context);
                _context.Database.CommitTransaction();
            }
            catch (Exception ex)
            {
                _context.Database.RollbackTransaction();
                throw new Exception("An error occured", ex);
            }
            finally
            {
                _context.Database.CommitTransaction();
            }
        }
    }
}