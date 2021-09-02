using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using smsc.SenderAPI.Core.Models;
using smsc.SenderAPI.Core.Sms;
using smsc.SenderAPI.Handlers.DTO;
//using smsc.SenderAPI.Handlers.DTO;
using smsc.SenderAPI.Infrastructure;

namespace smsc.SenderAPI.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class SendController : ControllerBase
    {

        private readonly IContext _context;
        private readonly SmsSender _sender;
        public SendController(IContext ctx, SmsSender sender)
        {
            this._context = ctx;
            this._sender = sender;
        }

        [Route("send")]
        [HttpGet]
        public async Task<IActionResult> Send(string key, string src, string dst, string text)
        //public async Task<IActionResult> Send(SendGetRequest send) 
        {
            if (String.IsNullOrEmpty(key))
                return Unauthorized("Unauthorized");

            if (String.IsNullOrEmpty(src) && src.Length <= 0)
                return BadRequest("src is required");
            if (String.IsNullOrEmpty(dst) && dst.Length <= 0)
                return BadRequest("dst is required");
            if (String.IsNullOrEmpty(text))
                return BadRequest("text is required");
            var user =await _context.Users.GetByApiKey(key);
            if (user == null)
                return Unauthorized("User Not Found");
            var alphanumeric = await _context.Alphanumerics.GetByName(src);
            if (alphanumeric == null)
                return BadRequest("Alphanumeric Not Found");
            var alphanumericAccess =await _context.AlphanumericAccesses.GetByUserAlphanumeric(alphanumeric, user);
            if (alphanumericAccess == null)
                return BadRequest("You are not have request");

            var message = await _context.Messages.Insert(new Message
            {
                Alphanumeric = alphanumeric.Name,
                UserId = user.Id,
                Phone=dst,
                Content=text,
            });

            var queue = await _context.Queues.Insert(new Queue
            {
                MessageId = message.Id, 
                Priority = 0,
                Type = "Default"
            }); 

            return Ok(new { MessageId = message.Id });
        }

    }

    
}
