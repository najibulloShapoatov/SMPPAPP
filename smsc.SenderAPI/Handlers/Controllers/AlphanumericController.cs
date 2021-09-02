using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using smsc.SenderAPI.Core.Models;
using smsc.SenderAPI.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smsc.SenderAPI.Handlers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlphanumericController : ControllerBase 
    {
        private readonly IContext _context;
        private readonly Alphanumeric _sender;
        public AlphanumericController(IContext ctx, Alphanumeric sender)
        {
            this._context = ctx;
            this._sender = sender;
        }
    }
}
