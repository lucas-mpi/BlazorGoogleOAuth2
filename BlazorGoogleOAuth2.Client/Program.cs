using BlazorGoogleOAuth2.Client;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace BlazorGoogleOAuth2.Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.Services.AddAuthorizationCore();
            builder.Services.AddCascadingAuthenticationState();
            builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();
          
            builder.Services.AddOidcAuthentication(options =>
            {
                builder.Configuration.Bind("Google", options.ProviderOptions);
            });


            await builder.Build().RunAsync();
        }
    }
}
