using DataAccessLayer.Data;
using DataAccessLayer.Repository.Interfaces;
using DataAccessLayer.Repository.Implementations;

var builder = WebApplication.CreateBuilder(args);

// 🔥 Add services to the container.
builder.Services.AddControllersWithViews();

// ✅ Dapper Context
builder.Services.AddScoped<DapperContext>();

// ✅ Repository DI
builder.Services.AddScoped<IContactRepository, ContactRepository>();

var app = builder.Build();

// 🔧 Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

// Static files (CSS, JS, Bootstrap)
app.UseStaticFiles();   // 🔥 IMPORTANT

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();