using APICDA.Controllers;
using APICDA.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.UserSecrets;


var builder = WebApplication.CreateBuilder(args);


// Récupère la configuration de l'application
var configuration = new ConfigurationBuilder()
    .AddUserSecrets<LoginController>()
    .Build();

// Récupère la clé API à partir des secrets
string apiKey = configuration["APICDA:PrivateKey"];
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ShopDbContext>(options => options.UseInMemoryDatabase("ShopDb"));



var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (IServiceScope serviceScope = app.Services.CreateScope())
{
    var services = serviceScope.ServiceProvider;
    var dbContext = services.GetService<ShopDbContext>();
    SeedUser.SeedAsync(dbContext);
    // Insérer vos données ici
}

app.Run();
