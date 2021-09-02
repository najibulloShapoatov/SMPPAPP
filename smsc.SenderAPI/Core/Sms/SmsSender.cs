using Inetlab.SMPP;
using Inetlab.SMPP.Common;
using Inetlab.SMPP.PDU;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using smsc.SenderAPI.Core.Statuses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace smsc.SenderAPI.Core.Sms
{
    public class SmsSender
    {
        private readonly SmsConfig conf;
        private readonly ILogger _logger;
      
        public SmsSender(IConfiguration configuration, ILoggerFactory loggerFactory)
        {//логгера принеси сюда
            this.conf = new SmsConfig();

            conf.host = configuration["smpp:host"];
            conf.port = Convert.ToInt32(configuration["smpp:port"]);
            conf.systemId = configuration["smpp:systemId"];
            conf.password = configuration["smpp:pass"];

            _logger = loggerFactory.CreateLogger(GetType().Name);

        }

        [Obsolete]
        public async Task<int> Send(string from, string to, string message)
        {


            using (SmppClient client = new SmppClient())
            {
                try
                {
                    if (await client.ConnectAsync(new DnsEndPoint(conf.host, conf.port, AddressFamily.InterNetwork)))
                    {
                        BindResp bindResp = await client.BindAsync(conf.systemId, conf.password);

                        if (bindResp.Header.Status == CommandStatus.ESME_ROK)
                        {
                            var resp = await client.Submit(
                               SMS.ForSubmit()
                                   .From(from, AddressTON.Alphanumeric, AddressNPI.Unknown)
                                   .To(to, AddressTON.International, AddressNPI.ISDN)
                                   .Coding(DataCodings.UCS2)
                                   .Text(message)
                               );
                            if (resp.All(x => x.Header.Status == CommandStatus.ESME_ROK))
                            {
                                _logger.LogInformation($"Sended sms from {from} to {to} content: {message}");
                                await client.DisconnectAsync();
                                return (int)MessageStatus.Ok;
                            }
                            _logger.LogError("Error on sending request send to smpp:", resp);
                            await client.DisconnectAsync();
                            return (int)MessageStatus.Error;
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError("Error on connect to smpp:"+ex.Message, ex);
                    return (int)MessageStatus.Pending;
                }
                _logger.LogError("Error on creating smpp client: Unknown Error" );
                return (int)MessageStatus.Pending;
            }

        }

        

    }
}

