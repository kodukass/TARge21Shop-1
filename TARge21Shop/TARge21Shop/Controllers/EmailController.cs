using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using NETCore.MailKit.Core;
using TARge21Shop.ApplicationServices.Services;
using TARge21Shop.Core.Dto;
using TARge21Shop.Core.ServiceInterface;
using TARge21Shop.Models;

namespace TARge21Shop.Controllers
{
    public class EmailController : Controller
    {
        private readonly IEmailServices _emailService;

        public EmailController(IEmailServices emailService)
        {
            _emailService = emailService;
        }


        [HttpPost]
        public IActionResult SendEmail1(EmailViewModel vm)
        {
            var dto = new EmailDto()
            {
                To = vm.To,
                Subject = vm.Subject,
                Body = vm.Body
            };
            _emailService.SendEmail(dto);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
