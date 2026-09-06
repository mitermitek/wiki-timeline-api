using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using wiki_timeline_api.Data;
using wiki_timeline_api.Entities;
using wiki_timeline_api.Middlewares;
using wiki_timeline_api.Repositories;
using wiki_timeline_api.Repositories.Interfaces;
using wiki_timeline_api.Services;
using wiki_timeline_api.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<WikiTimelineContext>(opt =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
    opt.UseMySQL(connectionString);
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(opt =>
    {
        opt.Cookie.HttpOnly = true;
        opt.Cookie.SameSite = SameSiteMode.Strict;
        opt.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        opt.Cookie.Name = "wikitimeline";
        opt.ExpireTimeSpan = TimeSpan.FromMinutes(15);
        opt.SlidingExpiration = true;
        opt.Cookie.IsEssential = true;
        opt.Cookie.MaxAge = TimeSpan.FromDays(14);

        opt.Events.OnRedirectToLogin = context =>
        {
            context.Response.StatusCode = 401;
            return Task.CompletedTask;
        };

        opt.Events.OnRedirectToAccessDenied = context =>
        {
            context.Response.StatusCode = 403;
            return Task.CompletedTask;
        };
    });

builder.Services.AddCors(opt =>
{
    var frontEndUrl = builder.Configuration.GetValue<string>("FrontEndUrl");
    if (string.IsNullOrEmpty(frontEndUrl))
    {
        throw new InvalidOperationException("FrontEndUrl is not configured.");
    }

    opt.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins(frontEndUrl)
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

builder.Services.AddScoped<IUserContextService, UserContextService>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseCors();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
