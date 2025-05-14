using Microsoft.AspNetCore.Authentication.Cookies;
using System.Text.Json;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

// Mensaje en consola al iniciar la aplicación
Console.WriteLine("========== INICIANDO APLICACIÓN ==========");
Console.WriteLine($"Entorno: {builder.Environment.EnvironmentName}");
Console.WriteLine($"Hora de inicio: {DateTime.Now}");
Console.WriteLine("==========================================");


//Add Session
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.Cookie.Name = $".{builder.Environment.ApplicationName}.Session";
    options.IdleTimeout = TimeSpan.FromHours(8);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

//Autenticacion
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    //Cookie Name
    options.Cookie.Name = $".{builder.Environment.ApplicationName}.Cookie";
    //Login
    options.LoginPath = "/Login";
    //LogOut
    options.LogoutPath = "/Login/Out";
    //Time to Expire
    options.ExpireTimeSpan = TimeSpan.FromHours(8);
    //Authorize
    options.AccessDeniedPath = "/Home/Error";

});

// Add services to the container.
builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
builder.Services
    .AddControllersWithViews(options =>
    {
        options.Filters.Add<Test_Gastos.Filters.ActionFilter>();
        options.Filters.Add<Test_Gastos.Filters.ErrorFilter>();
    })
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        options.JsonSerializerOptions.PropertyNameCaseInsensitive = false;
        options.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.WriteIndented = true;
    }
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseSession();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
