using NewDelegateEmailApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewDelegateEmailApp.Services
{
    internal class CommunicationService
    {
        private ISender _sender;

        public CommunicationService(ISender sender)
        {
          
            _sender = sender;
        }

        public void SendMessage(Member member, string message)
        {
            _sender.Send(member, message);
        }
    }
}
