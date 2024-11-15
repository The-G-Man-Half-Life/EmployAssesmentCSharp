using DotNetEnv;
using EmployAssesmentCSharp.Data;
using EmployAssesmentCSharp.Models;
using EmployAssesmentCSharp.Repositories.Interfaces;
using EmployAssesmentCSharp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

// Cargar las variables de entorno
Env.Load();

// Función para validar variables de entorno
void ValidateEnvVariables(params string[] variables)
{
    foreach (var variable in variables)
    {
        if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable(variable)))
        {
            throw new ArgumentNullException(variable, $"La variable de entorno {variable} no está configurada.");
        }
    }
}

// Validar las variables de entorno necesarias
ValidateEnvVariables("DB_HOST", "DB_PORT", "DB_UID", "DB_DATABASE", "DB_PASSWORD", "JWT_ISSUER", "JWT_AUDIENCE", "JWT_KEY");

var host = Environment.GetEnvironmentVariable("DB_HOST");
var port = Environment.GetEnvironmentVariable("DB_PORT");
var uid = Environment.GetEnvironmentVariable("DB_UID");
var database = Environment.GetEnvironmentVariable("DB_DATABASE");
var password = Environment.GetEnvironmentVariable("DB_PASSWORD");

var connectionString = $"server={host};port={port};database={database};uid={uid};password={password}";

var builder = WebApplication.CreateBuilder(args);

// Configurar el contexto de la base de datos
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.Parse("8.0.20-mysql")));

// Registrar servicios y repositorios
builder.Services.AddScoped<IDiseasRepository, DiseasServices>();
builder.Services.AddScoped<DiseasServices>();
// builder.Services.AddSingleton<Utilities>();

// builder.Services.AddAuthentication(config =>
// {
//     config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//     config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//     config.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
// })
// .AddJwtBearer(config =>
// {
//     config.RequireHttpsMetadata = false;
//     config.SaveToken = true;
//     config.TokenValidationParameters = new TokenValidationParameters
//     {
//         ValidateIssuer = true,
//         ValidIssuer = Environment.GetEnvironmentVariable("JWT_ISSUER"),
//         ValidateAudience = false,
//         ValidAudience = Environment.GetEnvironmentVariable("JWT_AUDIENCE"),
//         ValidateLifetime = true,
//         ClockSkew = TimeSpan.Zero,
//         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_KEY")!))
//     };
// });

// Registrar repositorios y servicios

// Configurar controladores y Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "EmployAssesmentCSharp", Version = "v1" });
    c.SwaggerDoc("v2", new OpenApiInfo { Title = "EmployAssesmentCSharp", Version = "v2" });
    c.EnableAnnotations();

    // c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    // {
    //     Description = "JWT Authorization header usando el esquema Bearer. Ejemplo: \"Bearer {token}\"",
    //     Name = "Authorization",
    //     In = ParameterLocation.Header,
    //     Type = SecuritySchemeType.Http,
    //     Scheme = "Bearer"
    // });

    // c.AddSecurityRequirement(new OpenApiSecurityRequirement
    // {
    //     {
    //         new OpenApiSecurityScheme
    //         {
    //             Reference = new OpenApiReference
    //             {
    //                 Type = ReferenceType.SecurityScheme,
    //                 Id = "Bearer"
    //             }
    //         },
    //         new string[] {}
    //     }
    // });
});

var app = builder.Build();

// Configurar middleware
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Version 1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseWelcomePage(new WelcomePageOptions
{
    Path = "/"
});

app.UseRouting();
app.UseHttpsRedirection();

// app.UseAuthentication(); 
// app.UseAuthorization();

app.MapControllers();
app.Run();
