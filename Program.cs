using NewDelegateEmailApp.Models;
using NewDelegateEmailApp.Repositories;
using NewDelegateEmailApp.Services;

namespace NewDelegateEmailApp
{
    internal class Program
    {

        static void Main(string[] args)
        {
            //by using delegates 
            //comment out next line for using dependency injection
           // ExecMethods.Execute(OptionsExec.WriteEmailSentNotificationinLogFile);
            
            //by using dependency injection (interfaces)}
            var senderemail = new EmailService();
            var senderssms = new SMSService();
            
            //aqui le deberia de estar inyectando la conexion a la bd pero no se lo inyecto
            //porque esta en el contexto
            var repository = new MemberRepository();
            var memberService = new MemberService(repository);
            //Following line is possible to change email or ssms
            var communicationService = new CommunicationService(senderemail);

            //method to get all members
            var members = memberService.GetAllMembers();

            var message = "Message to broadcast to each member ";
            foreach (var memb in members)
            {
                communicationService.SendMessage(memb, message);
                //Method for record the log on file or db
                //ExecMethods.RecordLogOnLogFile(memb);
                ExecMethods.RecordLogOnDB(memb);
            }
        }
       
    }
}