using FileUpload_Honeywell.Models;
using Microsoft.Extensions.Hosting.Internal;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IFileDetails, MockFileDetailsRepository>();

//builder.Services.Configure<IISServerOptions>(options =>
//{
//    options.MaxRequestBodySize = 102400 ;
//});
var app = builder.Build();

// Configure the HTTP request pipeline. 2147483648
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
