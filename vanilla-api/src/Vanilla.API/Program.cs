using Vanilla.API.Common;
using Vanilla.API.Common.DependencyInjections;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddProblemDetails();
builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddSwaggerGen();
builder.Services.AddExceptionHandler<ExceptionHandler>();
// builder.Services.AddAuthorization();
// builder.Services.AddHttpContextAccessor();
// builder.Host.UseSerilog((_, _, lc) =>
// {
//     lc.ReadFrom.Configuration(builder.Configuration);
// });
//

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
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
