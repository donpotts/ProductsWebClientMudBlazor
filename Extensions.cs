using ProductsWebClientMudBlazor.Authentication;
using ProductsWebClientMudBlazor.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;

namespace ProductsWebClientMudBlazor;

public static class Extensions
{
    public static void AddBlazorServices(this IServiceCollection services, string baseAddress)
    {
        services.AddMudServices();
        services.AddScoped<AppService>();

        services.AddScoped(sp
            => new HttpClient { BaseAddress = new Uri(baseAddress) });

        services.AddAuthorizationCore();
        services
            .AddScoped<AuthenticationStateProvider, JwtAuthenticationStateProvider>();
        
    }
}
