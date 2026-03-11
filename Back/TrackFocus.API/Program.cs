using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TrackFocus.Application.Service;
using TrackFocus.Domain.Entities;
using TrackFocus.Infraestructure.Data;
using TrackFocus.Infraestructure.Service;
using TrackFocus.API.Endpoints;
using TrackFocus.Application.Profiles.Security;
using AutoMapper;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Insira o token JWT desta maneira: Bearer seu_token_aqui"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

// Pegando Connection String
string connString = builder.Configuration.GetConnectionString("DbConnection");

// Adicionando Autor mapper passando Assembly do Profile 
// ✅ SOLUÇÃO: Registrar todos os assemblies que contêm profiles
builder.Services.AddAutoMapper(
    typeof(UserProfile).Assembly,           // Assembly do UserProfile
    typeof(TreinoProfile).Assembly,         // Assembly do TreinoProfile  
    typeof(ExercicioProfile).Assembly,
    typeof(CardioProfile).Assembly,
    typeof(SerieProfile).Assembly      // Assembly do ExercicioProfile
);

// Implementando Injeção de Dependência de Interface para Serviço
builder.Services.AddScoped(typeof(DAL<>));
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IUserService, UserService>();

// Adicionando DbContext

// Criando Identity, direcionando para IdentityUser e em qual contexto deve ser armazenado
builder.Services.AddIdentity<User,IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
// Adicionando Contexto para lidar com Entidades de Negócio 
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(connString);
});

// Adicionando Autenticação seguindo esquema padrão, com token recebendo parâmetros de validação
builder.Services.AddAuthentication(options =>
{
   options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; 
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes($"{builder.Configuration["JwtSettings:Secret"]}")),
        ValidateAudience = false,
        ValidateIssuer = false,
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddAuthorization();

// Adicionando Cross Origin Resource Sharing
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configurando Permissões do CORS
app.UseCors( options =>
{
   options.AllowAnyHeader()
          .AllowAnyMethod()
          .AllowAnyOrigin();
});

app.UseHttpsRedirection();
// Dizendo para o App que foi construído que ele pode usar autenticação
app.UseAuthentication();
// Mapeando End Point seguind padrões Minimal APIs
app.MapTreinoEndpoints();
app.MapUserEndpoints();
app.UseAuthorization();

app.Run();