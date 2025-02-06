using Vanilla.API.Common;
using Vanilla.API.Common.Extensions;
using Vanilla.Dtos.Common;
using Vanilla.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddProblemDetails();
builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddSwaggerGen();
builder.Services.AddExceptionHandler<ExceptionHandler>();
builder.Services.AddHttpContextAccessor();
// builder.Services.AddAuthorization();
// builder.Host.UseSerilog((_, _, lc) =>
// {
//     lc.ReadFrom.Configuration(builder.Configuration);
// });
//

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
    // using var scope = app.Services.CreateScope();
    // var initialiser = scope.ServiceProvider.GetRequiredService<DbInitialiser>();
    // await initialiser.InitialiseAsync();
    // await initialiser.SeedAsync();
}

app.UseHttpsRedirection();
app.UseRouting();

// app.UseAuthentication();
// app.UseAuthorization();

app.UseEndpoints(e =>
{
    e.MapControllers();
});

app.Run();
