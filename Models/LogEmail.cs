using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewDelegateEmailApp.Models
{
    public class LogEmail
    {
        public int Id { get; set; }
        public int IdMember { get; set; }
        public string Message { get; set; }
        public DateTime DateSent { get; set; }
    }
}
