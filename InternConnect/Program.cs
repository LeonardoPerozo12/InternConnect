using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using InternConnect.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

// Load user secrets
builder.Configuration.AddUserSecrets<Program>();

// Configure Entity Framework to use MySQL with Pomelo
builder.Services.AddDbContext<InternConnectContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("Connection"),
        new MySqlServerVersion(new Version(8, 0, 21)) // Especifica la versión de MySQL
    )
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAllOrigins"); // Agregar uso de CORS
app.UseAuthorization();

app.MapControllers();

app.Run();
