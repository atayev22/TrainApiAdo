using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;


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
            mail.From.Add(MailboxAddress.Parse("mayra.botsford17@ethereal.email"));
            mail.To.Add(MailboxAddress.Parse($"{mailArdess}"));
            mail.Subject = "Train App";
            mail.Body = new TextPart(text);


            //using var smtp = new SmtpClient;
            //smtp

            return Ok();
        }
    }
}
