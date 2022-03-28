using AutoMapper;
using DebetCards.Data;
using DebetCards.Managers;
using DebetCards.Mapping;
using DebetCards.Models;
using DebetCards.Models.Jwt;
using DebetCards.Report;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddDbContext<CardDbContext>(options =>
{
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("Postgres"),
        b => b.MigrationsAssembly("DebetCards"));
});

builder.Configuration.AddJsonFile("appsettings.ConfigClass.json");

builder.Services.AddScoped<IRepository<Card>, CardEFRepository>();
//builder.Services.AddScoped<IRepository<Card>, CardDbRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddTransient<IValidator<Card>, CardValidator>();
builder.Services.AddScoped<IUserManager, UserManager>();
builder.Services.AddScoped<ILoginManager, LoginManager>();
builder.Services.AddScoped<IReporter<CardForReport>, ReporterToConsole>();

var mapperConfiguration = new MapperConfiguration(m => m.AddProfile(new MappingProfile()));
var mapper = mapperConfiguration.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.Configure<JwtAccessOptions>(builder.Configuration.GetSection("Authentication:JwtAccessOptions"));

var jwtSettings = new JwtOptions();
builder.Configuration.Bind("Authentication:JwtAccessOptions", jwtSettings);

builder.Services.AddTransient<ILoginManager, LoginManager>();

builder.Services
    .AddAuthentication(
        x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = jwtSettings.GetTokenValidationParameters();
    });


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo 
    { 
        Title = "Debet Cards", 
        Version = "v1", 
        Description = "Geek Brains, факультет C#, курс Безопасная разработка"
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme()
            {
                Reference = new OpenApiReference(){Type = ReferenceType.SecurityScheme, Id = "Bearer"}
            },
            Array.Empty<string>()
        }
    });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DebetCards"));
}

app.UseHttpsRedirection();

app.UseAuthentication(); 
app.UseAuthorization();

app.MapControllers();

app.Run();
