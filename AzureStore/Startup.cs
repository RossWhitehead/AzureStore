using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AzureStore.Startup))]
namespace AzureStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
