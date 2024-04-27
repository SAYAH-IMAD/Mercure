using Mercure.Patient.API;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHeaderPropagation(options => options.Headers.Add("authorization"));
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(configuration => configuration.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

builder.Services.AddHttpClient<IUserProxy, UserProxy>((provider, client) => { client.BaseAddress = new Uri("https://localhost:7021/"); })
    .AddHeaderPropagation(options => options.Headers.Add("authorization"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHeaderPropagation();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
