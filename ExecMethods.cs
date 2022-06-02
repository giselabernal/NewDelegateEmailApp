using NewDelegateEmailApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewDelegateEmailApp
{
    public static class ExecMethods
    {
        public delegate void EmailSentNotificationDelegate(string notificationMsg);
        static List<string> GetListofEmailIdForGoldMembers()
        {
            List<string> ListOfEmailIds = new List<string>();
            using (var context = new EFCoreDemoContext())
            {
                foreach(var member in context.Members)
                {
                    ListOfEmailIds.Add(member.Email);
                }
            }
            return ListOfEmailIds;
        }

        //after creating delegate, we have to create the method or methods
        //Create a method to send the email messages
        public static void SendMailtoAllGoldMembers(EmailSentNotificationDelegate EmailSentNotification)
        {
            foreach (var emailId in GetListofEmailIdForGoldMembers())
            {
                //logic for sending the mail to all the gold members  
                System.Threading.Thread.Sleep(2000); //assuming that it will take 2 seconds to send a mail.   
                EmailSentNotification($"Email Id {emailId} : mail sent");
            }
        }

        
    }
}
