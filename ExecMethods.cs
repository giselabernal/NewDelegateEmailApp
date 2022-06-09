using NewDelegateEmailApp.Data;
using NewDelegateEmailApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NewDelegateEmailApp
{
    public class ExecMethods
    {
        delegate void EmailSentNotificationDelegate(Member member, string notificationMsg);

        //Following method is only executed if line 14 in Program is uncommented out
        /// si es 1 dejara el log en consola
        /// si es 2 dejara el log en un archivo 
        /// si es 3 lo guardara en la base de datos
        public static void Execute(OptionsExec option)
        {
            switch (option)
            {
                case OptionsExec.WriteEmailSentNotificationOnConsole:
                    SendMailtoAllGoldMembers(WriteEmailSentNotificationOnConsole);
                    break;
                case OptionsExec.WriteEmailSentNotificationinLogFile:
                    SendMailtoAllGoldMembers(WriteEmailSentNotificationinLogFile);
                    break;
                case OptionsExec.WriteEmailSentNotificationinDatabase:
                    SendMailtoAllGoldMembers(WriteEmailSentNotificationinDatabase);
                    break;
                default: throw new ArgumentOutOfRangeException(nameof(option));
            }

        }
        //method that works for SendMailtoAllGoldMembers methods only
        private static List<Member> GetListofMembers()
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

        private static void SendMailtoAllGoldMembers(EmailSentNotificationDelegate EmailSentNotification)
        {
            foreach (var member in GetListofMembers())
            {
                //logic for sending the mail to all the  members  
                System.Threading.Thread.Sleep(2000); //assuming that it will take 2 seconds to send a mail.   
                EmailSentNotification(member, $" {member.Name}, EmailID {member.Email} : Email sent successfully");
            }
        }

        public static void RecordLogOnLogFile(Member member)
        {
            EmailSentNotificationDelegate EmailSentNotification = new EmailSentNotificationDelegate(WriteEmailSentNotificationinLogFile);
            EmailSentNotification(member, $" {member.Name}, EmailID {member.Email} : Email sent successfully");
        }

        public static void RecordLogOnDB(Member member)
        {
            EmailSentNotificationDelegate EmailSentNotification = new EmailSentNotificationDelegate(WriteEmailSentNotificationinDatabase);
            EmailSentNotification(member, $" {member.Name}, EmailID {member.Email} : Email sent successfully");
        }

        static void WriteEmailSentNotificationOnConsole(Member member, string notificationMsg)
        {
            Console.WriteLine(notificationMsg);
        }

        static void WriteEmailSentNotificationinLogFile(Member member, string notificationMsg)
        {
            System.IO.File.AppendAllText(@"c:\\delexample\log.txt", $"\n Id Member: {member.MemberId} - {notificationMsg}");
        }
        static void WriteEmailSentNotificationinDatabase(Member member, string notificationMsg)
        {
            InsertTheLogDetailsIntoDatabase(member, notificationMsg);
        }
        static void InsertTheLogDetailsIntoDatabase(Member member, string notificationMsg)
        {
            try
            {
                using (var context = new EFCoreDemoContext())
                {
                    var emaillog = new LogEmail();
                    emaillog.IdMember = member.MemberId;
                    emaillog.Message = notificationMsg;
                    emaillog.DateSent = DateTime.Now.Date;
                    context.LogEmails.Add(emaillog);
                    context.SaveChanges();
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }
    }

    public enum  OptionsExec
    {
        WriteEmailSentNotificationOnConsole=1,
        WriteEmailSentNotificationinLogFile=2,
        WriteEmailSentNotificationinDatabase=3
    }
}
