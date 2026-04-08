using EMS.DAL.Data;
using EMS.DAL.Repository;
using EMS.DAL.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllersWithViews();

// DB Context
builder.Services.AddDbContext<EMSDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repository DI
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

// Session
builder.Services.AddSession();

var app = builder.Build();

// Error Handling
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

// Session
app.UseSession();

app.UseAuthorization();


//  SEED DATA (ADMIN CREATE)
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<EMSDbContext>();

    // SAME NAME use karna hai
    if (!context.UserInfos.Any(u => u.Role == "Admin"))
    {
        context.UserInfos.Add(new UserInfo
        {
            EmailId = "admin@gmail.com",
            UserName = "Admin",
            Password = "admin123",
            Role = "Admin"
        });

        context.SaveChanges();
    }
}

// Default Route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();