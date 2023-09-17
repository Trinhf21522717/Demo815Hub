using Microsoft.AspNetCore.SignalR;
using Advanced.Models;

using System.Net;

// Bật hỗ trợ cho TLS 1.1 và TLS 1.2
ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddSignalR();

// builder.Services.AddSingleton<IWebHostEnvironment>(env => env.GetRequiredService<IWebHostEnvironment>());

var app = builder.Build();

app.MapControllers();

app.UseStaticFiles();

app.MapHub<RealTimeImageHub>("/RealTimeImage");
app.MapHub<RealTimeMessageHub>("/RealTimeMessage");
app.MapControllerRoute("default", // Tên thư mục
    "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();



app.Run();