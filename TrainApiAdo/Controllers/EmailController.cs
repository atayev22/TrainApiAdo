using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;

namespace TrainApiAdo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        [HttpPost]
        public IActionResult SendMail(string text,string mailArdess)
        {

            MimeMessage mail = new MimeMessage();
            mail.From.Add(MailboxAddress.Parse("atayevkamran222@gmail.com"));
            mail.To.Add(MailboxAddress.Parse($"{mailArdess}"));
            mail.Subject = "Uniser LLC";
            mail.Body = new TextPart(TextFormat.Text) { Text="Deyerli musderi"+text};


            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 465, true);
            smtp.Authenticate("atayevkamran222@gmail.com", "atayevkamran2002");
            smtp.Send(mail);
            smtp.Disconnect(true);

            return Ok();
        }
    }
}
