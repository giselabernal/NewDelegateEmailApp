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
            //ExecMethods.Execute(3);

            //by using dependency injection (interfaces)}
        
            var sender = new EmailService();
            //var connection = new MySQLConnection();
            // var connection = new OracleConnection();

            //  var repository = new CustomerRepository(connection);
            //aqui le deberia de estar inyectando la conexion a la bd pero no se lo inyecto
            //porque esta en el contexto
            var repository = new MemberRepository();
            var memberService = new MemberService(repository);
            var communicationService = new CommunicationService(sender);

            var members = memberService.GetAllMembers();

            var message = "Message to broadcast to all members";
            foreach (var memb in members)
            {
                communicationService.SendMessage(memb, message);
                //ExecMethods.SaveLog(memb);
                ExecMethods.WriteEmailSentNotificationinLogFile(memb, message);
            }
        }
       
    }
}