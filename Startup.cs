using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(News_Article_Project.Startup))]
namespace News_Article_Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
