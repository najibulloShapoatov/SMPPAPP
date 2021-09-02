using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using smsc.SenderAPI.Core.Models;
using smsc.SenderAPI.Core.Sms;
using smsc.SenderAPI.Infrastructure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace smsc.SenderAPI
{
    public class BackgroundSenderHostedService : IHostedService, IDisposable
    {
        private readonly IContext _context;
        private Timer _timer;
        private readonly ILogger _logger;
        private readonly SmsSender _sender;
        public BackgroundSenderHostedService(ILoggerFactory loggerFactory,IContext context, SmsSender sms)
        {
            _context = context; 
            _logger = loggerFactory.CreateLogger(GetType().Name);
            _sender = sms;
        }


        public void Dispose()
        {
            _timer?.Dispose();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation(
                 $"{GetType().Name} starting ");
            _timer = new Timer(Send, null, 2000, Timeout.Infinite); 

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{GetType().Name} stopping");
            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        [Obsolete]
        private async void Send(object state)
        {
            var watch = new Stopwatch();
            watch.Start();
            try
            {
                List<Queue> queues = await _context.Queues.GetQueueWithPriority();

                foreach (Queue queue  in queues)
                {
                    Message message = await  _context.Messages.GetById(queue.MessageId);
                    
                    if (message != null)
                    {
                        message.Status = await _sender.Send(message.Alphanumeric, message.Phone, message.Content);
                        if (message.Status == 0)
                            await _context.Queues.Delete(queue);
                    }

                }

            }catch(Exception ex)
            {
                _logger.LogError("Error in  sending  sms: "+ex.Message, ex);
            }
            finally
            {

            _timer.Change(Math.Max(0, watch.ElapsedMilliseconds), Timeout.Infinite);
            }
            


            
        }

       
    }

   
}

