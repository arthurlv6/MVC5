using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Business.SubBusinessAccess;
using DataModel.Entities;
using Microsoft.AspNet.Identity;

namespace WebSite.Filters
{
    internal class OperationRecordingFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var Controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            var Action = filterContext.ActionDescriptor.ActionName;
            var IP = filterContext.HttpContext.Request.UserHostAddress;
            var identity=HttpContext.Current.User.Identity;
            if (identity.IsAuthenticated)
            {
                var db = new SystemManagement();
                db.UserLoginRecord(new OperationRecord()
                {
                    DateTime = DateTime.Now, 
                    UserId = identity.GetUserId(),
                    Controller = Controller,
                    Action = Action,
                    Ip=IP,
                    Type = "Common"
                });
            }
        }
    }
}
