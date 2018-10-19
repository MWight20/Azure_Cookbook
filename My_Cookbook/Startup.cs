using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(My_Cookbook.Startup))]
namespace My_Cookbook
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
