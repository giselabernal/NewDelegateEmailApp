using NewDelegateEmailApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewDelegateEmailApp.Services
{
    public class SMSService : ISender
    {
        public void Send(Member member, string message)
        {
            Console.WriteLine($"Message by SSMS sent to: {member.MemberId}: Name: {member.Name} : mail {member.Email}");
        }
    }
}
