using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagementSystem.GlobalClass
{
    [Serializable]
    public class Notifications
    {
        private const string DictionaryName = "NOTIFICATIONS";
        private IList<Notification> _notifications;

        public Notifications(TempDataDictionary tempDataDictionary)
        {
            if (!tempDataDictionary.ContainsKey(DictionaryName))
            {
                tempDataDictionary[DictionaryName] = new List<Notification>();
            }
            _notifications = tempDataDictionary[DictionaryName] as IList<Notification>;
        }

        public IEnumerable<Notification> Current
        {
            get { return _notifications; }
        }

        public void Add(NotificationStatus status, string message)
        {
            _notifications.Add(new Notification { Status = status, Message = message });
        }
    }
}