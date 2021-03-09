using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Ivteks72.App.Areas.Identity.IdentityHostingStartup))]
namespace Ivteks72.App.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}