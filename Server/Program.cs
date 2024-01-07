using System.Reflection;
using Angular17WithASP.Application.Interfaces;
using Angular17WithASP.Application.Services;
using Angular17WithASP.Infrastucture;
using Angular17WithASP.Infrastucture.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddDbContext<DXFullAppContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"));
});

builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();

//restrict for prod
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

 if (app.Environment.IsDevelopment())
 {
     // uninstall Edi.RouteDebugger if not needed
     app.UseRouteDebugger();  //Ex usage: https://localhost:7292/route-debugger. This helps to know what the url should be
 }

 app.UseCors("AllowAllOrigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//app.MapFallbackToFile("/index.html");

app.Run();
