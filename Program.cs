using blogapp.Data;
using blogapp.Repository;
using blogapp.Service;
using blogapp.Service.impl;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
//builder.Services.AddRazorPages(); 

builder.Services.AddDbContext<BlogDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("BlogConnection")));

builder.Services.AddScoped<IPostService, PostServiceImpl>();

builder.Services.AddScoped<PostRepository>();
builder.Services.AddScoped<TagRepository>();


var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
