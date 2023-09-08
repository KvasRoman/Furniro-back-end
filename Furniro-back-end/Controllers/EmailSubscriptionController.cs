using Furniro.BusinessLogic.Email;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Furniro_back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailSubscriptionController : ControllerBase
    {
        IEmailSender _emailSender;
        public EmailSubscriptionController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }
        [HttpPost]
        public IActionResult Subscirbe(string Email,string type = "Default")
        {
            _emailSender.SendEmail(new Message(new string[] { Email }, "Subscription", "You have been subscirbed"));
            return Ok();
        }
    }
}
