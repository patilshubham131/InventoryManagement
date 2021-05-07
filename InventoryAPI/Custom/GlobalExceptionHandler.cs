using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http.ExceptionHandling;

namespace InventoryAPI.Custom
{
    public class GlobalExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            var exception = context.Exception;

            var httpExcpetion = exception as HttpException;

            if(httpExcpetion != null)
            {
                context.Result = new CustomError(httpExcpetion.Message, context.Request,(HttpStatusCode) httpExcpetion.GetHttpCode());
                return;
            }

            context.Result = new CustomError(httpExcpetion.Message, context.Request, HttpStatusCode.InternalServerError);
        }

    }
}