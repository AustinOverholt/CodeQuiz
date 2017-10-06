using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CodeQuiz.Startup))]
namespace CodeQuiz
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
