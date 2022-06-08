using NewDelegateEmailApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewDelegateEmailApp.Services
{
    public interface ISender
    {
        public void Send(Member member, string message);
      
    }
}
