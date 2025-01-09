using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Business.Core.Notifications
{
    public class Notification
    {
        public Notification(string Message)
        {
            this.Message = Message;
        }

        public string Message { get; set; }
    }
}
