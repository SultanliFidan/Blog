using BlogApp.BL.Services.Interfaces;
using Microsoft.AspNetCore.Builder.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BlogApp.BL.DTOs.Options;

namespace BlogApp.BL.Services.Implements
{
    public class EmailService : IEmailService
    {
        readonly SmtpClient _client;
        readonly MailAddress _from;
        readonly HttpContext Context;
        public EmailService(IOptions<EmailOptions> option, IHttpContextAccessor acc)
        {
            var opt = option.Value;
            _client = new(opt.Host, opt.Port);
            _client.Credentials = new NetworkCredential(opt.Sender, opt.Password);
            _client.EnableSsl = true;
            _from = new MailAddress(opt.Sender, "Fidan");
            Context = acc.HttpContext;
        }
        public void SendEmailConfirmation(string reciever, string name, string token)
        {
            MailAddress to = new(reciever);
            MailMessage msg = new MailMessage(_from, to);
            msg.IsBodyHtml = true;
            msg.Subject = "Confirm your email adress";
            string url = Context.Request.Scheme + "://" + Context.Request.Host + "/Account/VerifyEmail?token=" + token + "&user=" + name;
            //msg.Body = VerifyEmail.Replace("__$name", name).Replace("__$link", url);
            _client.Send(msg);
        }
    }
}
