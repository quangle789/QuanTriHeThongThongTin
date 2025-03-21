﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineShopV4.Startup))]
namespace OnlineShopV4
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
