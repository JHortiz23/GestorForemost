using GestorForemost.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//EN ESTA PARTE HACEMOS LA CONFIGURACION  NUESTRA CADENA DE CONEXION QUE SE ENCUNETRA EN APPSETTINGS, UTILIZANDO TAMBIEN EL DBCONTEXT
//SE INCLUYE EL NOMBRE LA CONEXION
//SE INCLUYE EL DBCONTEXT
//UNA VEZ QUE LA CONEXIÓN ESTÁ LISTA, SE HACE SCAFFOLDING A NUESTRA BASE DE DATOS EN SQL SERVER.
builder.Services.AddDbContext<GestorForemostContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("Conexion")));

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
