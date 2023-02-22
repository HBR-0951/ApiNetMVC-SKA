using ApiNetMVC_SKA.core.Repositories.ApiProductRepo;
using ApiNetMVC_SKA.core.Services.ApiProduct;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IApiProductServices, ApiProductServices>();
builder.Services.AddTransient<IApiProductRepo, ApiProductRepo>();

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
    pattern: "{controller=ApiProduct}/{action=Index}/{id?}");

app.Run();