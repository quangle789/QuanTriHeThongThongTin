﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace chatProject.hubs
{
    [HubName("DemoChat")]
    public class ChatDemo : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }

        //public void Connect(string name)
        //{
        //    Clients.Caller.connect(name);
        //}

        public void Message(string name , string message)
        {
            Clients.All.message(name, message);
        }
    }
}