using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using smsc.SenderAPI.Core.Models;
using smsc.SenderAPI.Core.Sms;
using smsc.SenderAPI.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smsc.SenderAPI.Handlers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class MessagesController : ControllerBase
    {
        private readonly IContext _context;
        public MessagesController(IContext ctx)
        {
            this._context = ctx;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get(string apiKey)
        {
            if (String.IsNullOrEmpty(apiKey))
                return Unauthorized("Unauthorized");
            User userId =await _context.Users.GetByApiKey(apiKey);
            if (userId == null)
            {
                return BadRequest("User not found");
            }
            List<Message> message = await _context.Messages.GetByUser(userId);
            if (message.Count == 0)
            {
                return BadRequest("This user not found message");
            }
            return Ok(message);
        }
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> Detail(long id, string apikey)
        {
            if (String.IsNullOrEmpty(apikey))
                return Unauthorized("Unauthorized");
            User userId = await _context.Users.GetByApiKey(apikey);
            if (userId == null)
            {
                return BadRequest("User not found");
            }
            Message message = await _context.Messages.GetByIdUser(id, userId.Id);
            if (message ==null)
            {
                return BadRequest("This user not found message");
            }
            return Ok(message);
        }
    }
}
