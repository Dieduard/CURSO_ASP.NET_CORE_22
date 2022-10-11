using CURSO_CRUD_ASPNETCORE_VS2022.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


#region NUESTRA INYECCION DE DEPENDENCIA DE ACCESO A TODOS LOS CONTROLADORES 
/* ESTA ES NUESTRA PRIMER INYECCION DE DEPENDENCIA PARA TENER ACCESO A TODOS NUESTROS CONTROLADORES */

builder.Services.AddDbContext<BD_PubContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("PubContext"));
}); 
#endregion



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
