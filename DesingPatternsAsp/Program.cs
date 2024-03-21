using DesignPatterns.Models.Data;
using DesignPatterns.Repository;
using DesingPatternsAsp.Configuration;
using Microsoft.EntityFrameworkCore;
using Tools.Earn;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//dependecy injection
builder.Services.Configure<MyConfig>(builder.Configuration.GetSection("MyConfig"));

builder.Services.AddTransient((localFactory) =>
{
    return new LocalEarnFactory(
           builder.Configuration.GetSection("MyConfig").GetValue<Decimal>("LocalPercentage"));
});

builder.Services.AddTransient((foreignFactory) =>
{
    return new ForeignEarnFactory(
        builder.Configuration.GetSection("MyConfig").GetValue<Decimal>("ForeignPercentage"),
        builder.Configuration.GetSection("MyConfig").GetValue<Decimal>("ForeignExtra"));
});

builder.Services.AddDbContext<DesignPatternsContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Connection"));
});

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
