using NewDelegateEmailApp.Models;
using NewDelegateEmailApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewDelegateEmailApp.Services
{
    public class MemberService
    {
        private IRepository _repository;

        public MemberService(IRepository repository)
        {
            _repository = repository;
        }

        public List<Member> GetAllMembers()
        {
            return _repository.GetAllMembers();
        }
    }
}
