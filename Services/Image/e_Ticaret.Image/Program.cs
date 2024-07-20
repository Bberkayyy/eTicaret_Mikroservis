using e_Ticaret.Image.DAL.Context;
using e_Ticaret.Image.Services;
using e_Ticaret.Image.Services.GoogleCloudServices;
using Google.Apis.Auth.OAuth2;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<GoogleCloudStorageConfigOptions>(builder.Configuration.GetSection("GoogleCloudConfig"));
builder.Services.AddDbContext<ImageContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddSingleton<ICloudStorageService, CloudStorageService>();

builder.Services.AddSingleton(provider =>
{
    var options = provider.GetRequiredService<IOptions<GoogleCloudStorageConfigOptions>>().Value;
    string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
    GoogleCredential googleCredential;

    if (environment == Environments.Production)
    {
        googleCredential = GoogleCredential.FromJson(options.GoogleStorageAuthFile);
    }
    else
    {
        googleCredential = GoogleCredential.FromFile(options.GoogleStorageAuthFile);
    }

    return googleCredential;
});

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.Run();
