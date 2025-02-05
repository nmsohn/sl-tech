using Vanilla.API.Common.DependencyInjections;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();
builder.Services.AddProblemDetails();
builder.Services.AddDatabase(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseEndpoints(e =>
{
    e.MapControllers();
});

app.Run();
