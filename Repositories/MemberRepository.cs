using NewDelegateEmailApp.Data;
using NewDelegateEmailApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewDelegateEmailApp.Repositories
{
    internal class MemberRepository : IRepository
    {
        //private EFCoreDemoContext _context;

        ////public MemberRepository(EFCoreDemoContext context)
        //{
        //    _context = context;
        //}

        public List<Member> GetAllMembers()
        {
            List<Member> ListOfEmailIds = new List<Member>();
            var context = new EFCoreDemoContext();
            return context.Members.ToList();
           
        }

    }
}
