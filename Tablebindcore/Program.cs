using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Reflection;
using Tablebindcore.Models;
using static Tablebindcore.Controllers.EmployeeController;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMemoryCache();
builder.Services.AddMvcCore();
builder.Services.AddKendo();

string connString = builder.Configuration.GetConnectionString("MyConnection");

//string connectionString = String.Format(Configuration.("MyConnection");

builder.Services.AddDbContext<ConnectionStringClass>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection"));

});
builder.Services.AddScoped<IEmployeeDAO, EmployeeDAO>();

//builder.Services.AddDbContext<ConnectionStringClass>(options => options.UseSqlServer(Configuration.GetConnectionStrings("MyConnection")));
//builder.Services.AddDbContext<ConnectionStringClass>(options => options.UseSqlServer("MyConnection"));



//string MyConnection = "server=.; database=Empdata;trusted_connection=true;encrypt=false";
//builder.Services.AddDbContext<ConnectionStringClass>(op => op.UseSqlServer("MyConnection"));



var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.AddSingleton<IConfiguration>(Configuration);
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Employee}/{action=Index}/{id?}");

app.Run();
