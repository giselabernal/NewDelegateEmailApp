using NewDelegateEmailApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewDelegateEmailApp.Repositories
{
    public interface IRepository
    {
        List<Member> GetAllMembers();
    }
}
