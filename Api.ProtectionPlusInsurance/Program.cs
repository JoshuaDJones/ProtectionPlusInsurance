namespace Api.ProtectionPlusInsurance;

using Infrastructure.ProtectionPlusInsurance.Database;
using Infrastructure.ProtectionPlusInsurance;
using Application.ProtectionPlusInsurance;

public partial class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddInfrastructure();
        builder.Services.AddApplication();

        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            var dbInit = scope.ServiceProvider.GetRequiredService<DatabaseInitializer>();
            dbInit.Initialize();
        }

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
