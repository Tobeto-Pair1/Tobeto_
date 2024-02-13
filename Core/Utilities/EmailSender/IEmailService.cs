using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace Core.Utilities.Business.EmailService
{
    public interface IEmailService
    {
        void Send(string to, string subject, string html, string from = null);
    }
}