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
            mail.From.Add(MailboxAddress.Parse("atayev222@bk.ru"));
            mail.To.Add(MailboxAddress.Parse($"{mailArdess}"));
            mail.Subject = "Uniser LLC";
            mail.Body = new TextPart(TextFormat.Text) { Text="Deyerli musderi"+text};


            using var smtp = new SmtpClient();
            smtp.Connect("smtp.mail.ru", 465, true); //SecureSocketOptions.StartTls
            smtp.Authenticate("atayev222@bk.ru", "bgECC83FKK5YnYgij3ec");
            smtp.Send(mail);
            smtp.Disconnect(true);

            return Ok();
        }
    }
}
