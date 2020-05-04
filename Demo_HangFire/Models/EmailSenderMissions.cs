using Hangfire.MissionControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace Demo_HangFire.Models
{
    public class EmailSenderMissions
    {
        [Mission(Name = "Send email",
                Description = "Send email to customer",
                Queue = "emails")]
        public string SendEmail(int customerId, string displayName)
        {
            Thread.Sleep(TimeSpan.FromSeconds(8));
            //Thread.SpinWait(60000);
            return customerId + ";"+ displayName;
        }
    }
}