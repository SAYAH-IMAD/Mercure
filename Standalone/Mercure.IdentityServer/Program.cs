using Mercure.Common.Persistence.DataReader;
using Mercure.IdentityServer.Configuration;
using Mercure.IdentityServer.Extensions;
using Mercure.IdentityServer.Repository.UserIdentity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSingleton<IUserClaimsRepository, UserClaimsRepository>();

string db = builder.Configuration.GetConnectionString("UserConnectionStrings");
builder.Services.AddSingleton<IAccessDB>(new AccessDB(db)
                .ConfigureMapping());

// TODO : configuration de l'authentification
builder.Services.AddIdentityServer()
    .AddDeveloperSigningCredential()
    .AddInMemoryIdentityResources(IdentityConfiguration.IdentityResources)
    .AddInMemoryApiResources(IdentityConfiguration.ApiResources)
    .AddInMemoryApiScopes(IdentityConfiguration.ApiScopes)
    .AddInMemoryClients(IdentityConfiguration.Clients)
    .AddInMemoryUser();

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

app.UseIdentityServer();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
