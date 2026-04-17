using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Load ocelot.json config
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

// 🔹 Add Ocelot services
builder.Services.AddOcelot();

var app = builder.Build();

// ❌ Remove this line
// app.MapGet("/", () => "Hello World!");

// 🔹 Use Ocelot middleware (important)
await app.UseOcelot();

app.Run();