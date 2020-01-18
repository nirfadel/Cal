    using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.OAuth;
using CalApiProject.BLL;
using System.Web.Http;
using CalApiProject.DAL;

[assembly: OwinStartup(typeof(CalApiProject.CalStartup))]

namespace CalApiProject
{
    public class CalStartup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            UserMock mock = new UserMock();
            OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                //path of generting the token
                TokenEndpointPath = new PathString("/token"),
                //3 minutes token
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(3),
               
                Provider = new AuthorizationServerProvider(new UserRepository(mock))
            };
            //Token Generations
            app.UseOAuthAuthorizationServer(options);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);

        }
    }
}
