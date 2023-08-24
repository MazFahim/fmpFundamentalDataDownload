using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using P3.FundamentalData.Web.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<P3FundamentalDataWebContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("P3FundamentalDataWebContext") ?? throw new InvalidOperationException("Connection string 'P3FundamentalDataWebContext' not found.")));

builder.Services.AddHttpClient(); 
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient("baseurl", client =>
{

    client.BaseAddress = new Uri("https://localhost:7258");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}");

app.Run();
