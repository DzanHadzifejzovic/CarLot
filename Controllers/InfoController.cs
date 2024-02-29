using FluentEmail.Core;
using FluentEmail.Smtp;
using Microsoft.AspNetCore.Mvc;
using MVCAssign1.ViewModel;
using System.Net;
using System.Net.Mail;

namespace MVCAssign1.Controllers
{
    public class InfoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Contact(EmailViewModel emailVM)
        {

            string fromMail = emailVM.FromEmail;
            string fromPassword = "gJGypRIAMc5v20d7"; //nwwasjmdfmaurkyy //gJGypRIAMc5v20d7

            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.Subject=emailVM.Subject;
            message.To.Add(new MailAddress("dzanhadzifejzovic123@gmail.com"));
            message.Body = "<html><body>"+emailVM.Body+ "</html></body>";
            message.IsBodyHtml = true;

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port=465,
                Credentials=new NetworkCredential(fromMail,fromPassword),
                EnableSsl=false
            };

            smtpClient.Send(message);   

            return RedirectToAction("Index", "Car");
        }

    }
}
