using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace InventoryAPI.App_Start
{
    public static class Bootstrapper
    {
        public static void Run()
        {
            AutoFacWebApiConfig.Init(GlobalConfiguration.Configuration);
        }
    }
}