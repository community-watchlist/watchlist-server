using Api.Modules;
using Infrastructure;
using Infrastructure.Persistence;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

await app.InitialiseDatabaseAsync();

app.UseCors();
app.MapControllers();

app.Run();
