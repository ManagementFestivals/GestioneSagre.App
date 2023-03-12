namespace GestioneSagre.App;

public class Program
{
    public static async Task Main(string[] args)
    {
        //Riferimento: https://github.com/AngeloDotNet/WebApi.IdentityJWT

        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

        builder.Services.AddBlazoredLocalStorage();
        builder.Services.AddAuthorizationCore();

        builder.Services.AddScoped<AppAuthenticationStateProvider>();
        builder.Services.AddScoped<AuthenticationStateProvider>(provider => provider.GetRequiredService<AppAuthenticationStateProvider>());

        await builder.Build().RunAsync();
    }
}