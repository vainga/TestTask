using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers(); 
        var app = builder.Build();

        app.UseRouting();
        app.UseAuthorization();
        app.MapControllers(); 

        app.Run();
    }
}
