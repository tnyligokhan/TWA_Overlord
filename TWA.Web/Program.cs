using TWA.Data;
using TWA.Service;
using TWA.Web.Hubs;

var builder = WebApplication.CreateBuilder(args);

// 1. Katmanları Enjekte Et (Dependency Injection)
// Data Katmanı (Veritabanı bağlantısı burada kurulur)
builder.Services.AddDataLayer(builder.Configuration);

// Service Katmanı (Business Logic ve AI burada kurulur)
builder.Services.AddServiceLayer();

// Web Katmanı Servisleri
builder.Services.AddControllersWithViews();

// SignalR Eklendi (Canlı Veri İçin)
builder.Services.AddSignalR();

// Background Worker Kaydı
builder.Services.AddHostedService<TWA.Web.Workers.AttackBackgroundService>();
builder.Services.AddHostedService<TWA.Web.Workers.LiveDataBroadcastService>();

var app = builder.Build();

// 2. Middleware Hattı (HTTP Request Pipeline)
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");

// SignalR Hub Endpoint
app.MapHub<GameDataHub>("/gameDataHub");

app.Run();
