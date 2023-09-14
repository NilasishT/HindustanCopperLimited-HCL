using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hindustancopperlimited.GlobalClass
{
    [Serializable]
    public class Notification
    {
        public NotificationStatus Status { get; set; }

        public string Message { get; set; }
    }

    public enum NotificationStatus
    {
        Error, Warning, Success, Info, CloseWindow
    }
}