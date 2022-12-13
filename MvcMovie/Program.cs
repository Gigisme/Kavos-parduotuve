using MvcMovie.db;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddSingleton<Db>();

var app = builder.Build();

app.Logger.LogInformation("test");
app.Logger.LogInformation(app.Configuration["DbConnStr"]);

using (var serviceScope = app.Services.CreateScope())
{
    var services = serviceScope.ServiceProvider;    

    var tst = services.GetRequiredService<Db>();
}

//var db = app.Services.
//db.Bla();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
