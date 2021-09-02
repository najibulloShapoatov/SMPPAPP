using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smsc.SenderAPI.Core.Statuses
{
    //public static class MessageStatus
    //{
      //  public static string Ok { get; set; } = "Pending errot";
    //} 
    public enum MessageStatus
    {
        Ok=0,
        Pending,
        Error

    }
}