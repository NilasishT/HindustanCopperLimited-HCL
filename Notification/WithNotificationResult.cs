using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagementSystem.GlobalClass
{
    public class WithNotificationResult : ActionResult
    {
        private readonly ActionResult _result;
        private readonly NotificationStatus _status;
        private readonly string _message;

        public WithNotificationResult(ActionResult result, NotificationStatus status, string message)
        {
            _result = result;
            _status = status;
            _message = message;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            // Add the notification
            context.Controller.Notifications().Add(_status, _message);

            // Continue with execution
            _result.ExecuteResult(context);
        }
    }
}