using Microsoft.EntityFrameworkCore;
using backendnet.Data;
var builder = WebApplication.CreateBuilder(args);
// Agrega el soporte para MySQL
var connectionString = builder.Configuration.GetConnectionString("DataContext");
builder.Services.AddDbContext<DataContext>(options =>
{
options.UseMySql (connectionString, ServerVersion.AutoDetect (connectionString));
});
// Agrega la funcionalidad de controladores 
builder.Services.AddControllers();

// Agrega la funcionalidad de controladores 
builder.Services.AddControllers();
// Agrega la documentación de la API
builder.Services.AddSwaggerGen();

// Construye la aplicación web 
var app = builder. Build();

// Si queremos mostrar la documentación de la API en la raíz 
if (app.Environment.IsDevelopment()) 
{

    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "backend v1"); 
        options.RoutePrefix = string.Empty;
    });
}



// Redirige a HTTPS
app.UseHttpsRedirection();
// Utiliza rutas para los endpoints de los controladores
app . UseRouting();
// Establece el uso de rutas sin especificar una por default 
app.MapControllers();
app.Run();