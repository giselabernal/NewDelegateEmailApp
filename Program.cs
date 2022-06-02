namespace NewDelegateEmailApp
{
    internal class Program
    {
        delegate void EmailSentNotificationDelegate(string notificationMsg);

        static void Main(string[] args)
        {
            ExecMethods.SendMailtoAllGoldMembers(WriteEmailSentNotificationOnConsole);
        }

        static void WriteEmailSentNotificationOnConsole(string notificationMsg)
        {
            Console.WriteLine(notificationMsg);
        }

        //Create a method to write log in log file
        static void WriteEmailSentNotificationinLogFile(string notificationMsg)
        {
            System.IO.File.AppendAllText(@"c:\\delexample\log.txt", $"\n {notificationMsg}");
        }
        //Create a method to write log in database
        static void WriteEmailSentNotificationinDatabase(string notificationMsg)
        {
            InsertTheLogDetailsIntoDatabase(notificationMsg);
        }

        static void InsertTheLogDetailsIntoDatabase(string notificationMsg)
        {
            throw new NotImplementedException();
        }
    }
}