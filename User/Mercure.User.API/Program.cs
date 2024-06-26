using Mercure.Common.Configuration;
using Mercure.Common.Extension;
using Mercure.User.API;
using Mercure.User.Application;
using Mercure.User.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

Jwt jwt = builder.Configuration.GetSection(nameof(Jwt)).Get<Jwt>();

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDefaultHeaderPropagation();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = $"{Assembly.GetAssembly(typeof(Program)).GetName().Name}",
        Version = "v1"
    });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
});

builder.Services.AddApplication();

builder.Services.AddInfrastructure();

builder.Services.AddHttpClient<IPatientProxy, PatientProxy>((configuration) => { configuration.BaseAddress = new Uri("https://localhost:7021/"); })
                .AddHeaderPropagation();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
{
    options.Authority = jwt.Authority;
    options.Audience = jwt.Audience;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateAudience = false
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHeaderPropagation();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
