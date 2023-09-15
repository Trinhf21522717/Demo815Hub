using Microsoft.AspNetCore.SignalR;
using Advanced.Models;

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