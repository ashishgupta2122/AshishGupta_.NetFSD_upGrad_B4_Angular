using EMS.DAL.Data;
using EMS.DAL.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//  Add services
builder.Services.AddControllersWithViews();

//  DB Context
builder.Services.AddDbContext<EMSDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//  Repository DI
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

//  SESSION ADD
builder.Services.AddSession();

var app = builder.Build();

//  ERROR HANDLING (VERY IMPORTANT)
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();

//  SESSION USE
app.UseSession();

app.UseAuthorization();

//  DEFAULT ROUTE (LOGIN FIRST)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();