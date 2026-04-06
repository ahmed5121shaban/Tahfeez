using Tahfeez.Infrastracture.Persistence;

namespace Tahfeez.Api.Extentions
{
    public static class OpeniddictConfigExtentions
    {
        public static void AddOpenIddictConfig(this WebApplicationBuilder builder)
        {
            builder.Services.AddOpenIddict()
                .AddCore(options =>
                {
                    options.UseEntityFrameworkCore()
                        .UseDbContext<AppDbContext>();
                })
                .AddServer(options =>
                {
                    // flows
                    options.AllowPasswordFlow();
                    options.AllowRefreshTokenFlow();
                    options.AllowAuthorizationCodeFlow();
                    options.AllowClientCredentialsFlow();

                    // end points
                    options.SetTokenEndpointUris("/connect/token");
                    options.SetIntrospectionEndpointUris("/connect/introspect");
                    options.SetRevocationEndpointUris("/connect/revoke");
                    options.SetUserInfoEndpointUris("/connect/userinfo");

                    // token lifetimes
                    options.SetAccessTokenLifetime(TimeSpan.FromMinutes(15));
                    options.SetRefreshTokenLifetime(TimeSpan.FromDays(30));

                    options.AddDevelopmentEncryptionCertificate()
                           .AddDevelopmentSigningCertificate();

                    options.UseAspNetCore()
                           .EnableTokenEndpointPassthrough()
                           .EnableUserInfoEndpointPassthrough();
                })
                .AddValidation(options =>
                {
                    options.UseLocalServer();
                    options.UseAspNetCore();
                });
        }
    }
}
