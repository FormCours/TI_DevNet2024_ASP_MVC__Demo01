var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
// - Middleware custom
app.Use(async (context, next) =>
{
    Console.WriteLine("Bonjour !" +
                      "\n - Méthode : " + context.Request.Method +
                      "\n - Route : " + context.Request.Path);

    await next(); // -> Go to next middleware

    Console.WriteLine("Au revoir !" +
                      "\n - Méthode : " + context.Request.Method +
                      "\n - Route : " + context.Request.Path);
});

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Routing
// - Par default -> Ne pas le delete =)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// - Route custom pour un blog avec un slug
app.MapControllerRoute(
    name: "blog",
    pattern: "blog/{slug}",
    defaults: new
    {
        controller = "Blog",
        action = "Example"
    }
);

app.Run();
