using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BasicWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Starter en web server
            // lytter på port 80
            // bruker configurert settings til å svare på http requests
            Host
            .CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(
                webBuilder =>
                webBuilder.UseStartup<Startup>())
            .Build()
            .Run();
        }
    }
}
