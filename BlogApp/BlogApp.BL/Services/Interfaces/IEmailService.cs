using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BL.Services.Interfaces
{
    internal interface IEmailService
    {
        void SendEmailConfirmation(string reciever, string name, string token);
    }
}
