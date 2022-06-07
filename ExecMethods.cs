using NewDelegateEmailApp.Data;
using NewDelegateEmailApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewDelegateEmailApp
{
    public static class ExecMethods
    {
        public delegate void EmailSentNotificationDelegate(Member member,string notificationMsg);
        //static List<string> GetListofEmailIdForGoldMembers()

        public static void Execute(int opcion)
        {
            switch (opcion)
            {
                case 1:
                    SendMailtoAllGoldMembers(WriteEmailSentNotificationOnConsole);
                    break;
                case 2:
                    SendMailtoAllGoldMembers(WriteEmailSentNotificationinLogFile);
                    break;
                case 3:
                    SendMailtoAllGoldMembers(WriteEmailSentNotificationinDatabase);
                    break; 
            }
            
            
        }
        static List<Member> GetListofMembers()
        {
            List<Member> ListOfEmailIds = new List<Member>();
            var context = new EFCoreDemoContext();
            /*using (var context = new EFCoreDemoContext())
            {
                foreach(var member in context.Members)
                {
                    ListOfEmailIds.Add(member.Email);
                }
            }*/
            return context.Members.ToList();
        }

        //after creating delegate, we have to create the method or methods
        //Create a method to send the email messages
        public static void SendMailtoAllGoldMembers(EmailSentNotificationDelegate EmailSentNotification)
        {
            foreach (var member in GetListofMembers())
            {
                //logic for sending the mail to all the gold members  
                System.Threading.Thread.Sleep(2000); //assuming that it will take 2 seconds to send a mail.   
                EmailSentNotification(member, $" {member.Name}, EmailID {member.Email} : Email sent successfully");
            }
        }

        static void WriteEmailSentNotificationOnConsole(Member member, string notificationMsg)
        {
            Console.WriteLine(notificationMsg);
        }

        static void WriteEmailSentNotificationinLogFile(Member member, string notificationMsg)
        {
            System.IO.File.AppendAllText(@"c:\\delexample\log.txt", $"\n Id Member: {member.MemberId} - {notificationMsg}");
        }
        //Create a method to write log in database
        static void WriteEmailSentNotificationinDatabase(Member member, string notificationMsg)
        {
            InsertTheLogDetailsIntoDatabase(member, notificationMsg);
        }
        static void InsertTheLogDetailsIntoDatabase(Member member, string notificationMsg)
        {
            var context = new EFCoreDemoContext();
            var emaillog = new LogEmail();
            emaillog.IdMember = member.MemberId;
            emaillog.Message = notificationMsg;
            emaillog.DateSent = DateTime.Now.Date;

            context.LogEmails.Add(emaillog);
            context.SaveChanges();
            
        }

    }
}
