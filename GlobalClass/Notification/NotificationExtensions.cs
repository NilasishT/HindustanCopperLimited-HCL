using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hindustancopperlimited.GlobalClass
{
    public static class NotificationExtensions
    {
        // Action result extension method
        // Used within actions to add Notifications to results
        public static ActionResult WithNotification(this ActionResult actionResult, NotificationStatus status, string message)
        {
            return new WithNotificationResult(actionResult, status, message);
        }
        
        // Action result extension method
        // Used within actions to add Notifications to results
        public static ActionResult WithNotification(this ActionResult actionResult, NotificationStatus status)
        {
            string defaultMessage = "";
            if (status==NotificationStatus.Success)
            {
                defaultMessage = "Data Saved Successfully";
            }
            else if (status == NotificationStatus.Error)
            {
                defaultMessage = "Error Occurred";
            }
            else if (status == NotificationStatus.Warning)
            {
                defaultMessage = "Warning";
            }
            else
            {
                defaultMessage = "Info";
            }
            return new WithNotificationResult(actionResult, status, defaultMessage);
        }

        // Controller extension method
        // Used to hold retrieve the notifications from tempdata
        public static Notifications Notifications(this ControllerBase controller)
        {
            return new Notifications(controller.TempData);
        }

        // Html Helper extensions method
        // Used within Views to get the notifications THefrom temp data
        public static Notifications Notifications(this HtmlHelper htmlHelper)
        {
            return new Notifications(htmlHelper.ViewContext.TempData);
        }
    }
}