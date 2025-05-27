using MvcAWSElastiCache.Repositories;
using MvcAWSElastiCache.Services;

var builder = WebApplication.CreateBuilder(args);

// Añadimos servicios MVC y nuestro repositorio
builder.Services.AddTransient<RepositoryCoches>();
builder.Services.AddTransient<ServiceCacheRedis>();
builder.Services.AddControllersWithViews();

var app = builder.Build();



// Configuración del pipeline HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Para servir archivos estáticos (CSS, JS, etc.)
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Coches}/{action=Index}/{id?}"); // Cambiado para que cargue Coches por defecto

app.Run();
