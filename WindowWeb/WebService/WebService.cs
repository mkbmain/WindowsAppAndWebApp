using System;
using System.Web.Http;
using Microsoft.Owin.Hosting;
using Owin;

namespace WindowWeb.WebService
{
    public  class WebService
    {
        public  static void SpinUpWebService(int port)
        {
            string domainAddress = $"http://192.168.0.12:{port}/";

            using (WebApp.Start(url: domainAddress))
            {
                Console.WriteLine("Service Hosted " + domainAddress);
                System.Threading.Thread.Sleep(-1);
            }
        }

    }
}