using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using TARge21Shop.Core.Dto;

namespace TARge21Shop.Controllers
{
    public class EmailController : Controller
    {
        [HttpPost]
        public IActionResult SendEmail(string body)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("vernon98@ethereal.email"));
            email.To.Add(MailboxAddress.Parse("vernon98@ethereal.email"));
            email.Subject = "Test Email subject";
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = body };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("vernon98@ethereal.email", "5B5UfPDFBGpStWnNGc");
            smtp.Send(email);
            smtp.Disconnect(true);

            return Ok();
        }
        //[HttpPost]
        //public IActionResult SendEmail1(EmailModelViewModel vm)
        //{
        //    var dto = new EmailDto()
        //    {
        //        To=vm.To,
        //        Subject=vm.Subject,
        //        Body=vm.Body
        //    }
        //    _emailservices
        //}
    }
}
