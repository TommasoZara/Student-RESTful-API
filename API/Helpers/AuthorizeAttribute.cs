using API;
using API.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using static API.Enums;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var user = (User)context.HttpContext.Items["User"];
        if (user == null)
        {
            //--- utente non loggato 
            context.Result = new JsonResult(new { message = ErrorCode.Unauthorized.GetMessage() }) 
            { 
                StatusCode = StatusCodes.Status401Unauthorized 
            };

        }
    }
}