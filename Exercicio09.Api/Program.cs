#region BuilderServices


using Exercicio09.Api.Filters;
using Exercicio09.Api.Handlers;
using Exercicio09.Domain.Interfaces.Repositories;
using Exercicio09.Domain.Interfaces.Services;
using Exercicio09.Domain.Services;
using Exercicio09.Domain.Settings;
using Exercicio09.Infrastructure.Contexts;
using Exercicio09.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers(op =>
{
    op.Filters.Add(typeof(ExeptionFilter));
    op.Filters.Add(typeof(ValidationFilter));
}).AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
builder.Services.AddHttpContextAccessor();

#region HttpContext

builder.Services.AddHttpContextAccessor();

#endregion

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


#region Swagger

builder.Services.AddSwaggerGen(options => 
{
    
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
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

#endregion


#region AppSettings

var appSetting = builder.Configuration.GetSection(nameof(AppSetting)).Get<AppSetting>();
builder.Services.AddSingleton(appSetting);

#endregion

#region Mapper

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

#endregion

#region Services

builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IEnderecoService, EnderecoService>();
builder.Services.AddScoped<IDepartamentoService, DepartamentoService>();
builder.Services.AddScoped<ICursoService, CursoService>();
builder.Services.AddScoped<IPerfilService, PerfilService>();



#endregion

#region Repositories

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IEnderecoRepository, EnderecoRepository>();
builder.Services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();
builder.Services.AddScoped<ICursoRepository, CursoRepository>();
builder.Services.AddScoped<IPerfilRepository, PerfilRepository>();
builder.Services.AddScoped<ICepApiRepository, CepApiRepository>();

#endregion

#region Dbcontext

builder.Services.AddDbContext<Exercicio09Context>(options =>
{
    options.UseSqlServer(appSetting.SqlServerConnection);
    options.UseLazyLoadingProxies();
});

#endregion

#region HttpClient

builder.Services.AddHttpClient<ICepApiRepository, CepApiRepository>(options =>
{
    options.BaseAddress = new Uri(appSetting.ApiCep);
});


#endregion

#region Jwt
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option =>
{
    option.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(appSetting.JwtSecurityKey)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});
#endregion

#region Authorization
builder.Services.AddAuthorization(options =>
{
    options.InvokeHandlersAfterFailure = true;
}).AddSingleton<IAuthorizationMiddlewareResultHandler, AuthorizationHandler>();

#endregion

#endregion

#region AppConfiguration

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();


#endregion

