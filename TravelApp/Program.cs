using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using TravelApp.Settings;
using System.Text;
using TravelApp.Data;
using TravelApp.Interfaces;
using TravelApp.Models;
using TravelApp.Services;
using TravelApp.Mappings;
using System.IO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ConfigurationManager configuration = builder.Configuration;
builder.Services.AddControllers();
builder.Services.AddIdentity<Korisnik, AppRole>()
    .AddRoles<AppRole>()
    .AddEntityFrameworkStores<AppDbContext>();

JwtSettings _jwtSettings = new JwtSettings();
configuration.Bind(nameof(JwtSettings), _jwtSettings);
builder.Services.AddSingleton(_jwtSettings);
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer("server=localhost\\SQLEXPRESS;database=TuristickaAgencija;trusted_connection=true;encrypt=false"));

builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<IIdentityService, IdentityService>();
builder.Services.AddScoped<IDestinacijaService, DestinacijaService>();
builder.Services.AddScoped<IKorisnikDestinacija, KorisnikDestinacijaService>();
builder.Services.AddScoped<IKomentarService, KomentarService>();
builder.Services.AddScoped<IPaketService, PaketService>();
builder.Services.AddScoped<IDestinacijaPaketaService>(provider =>
    new DestinacijaPaketaService(provider.GetRequiredService<AppDbContext>(),
    Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(PaketMappingProfile).Assembly);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
            ValidateIssuerSigningKey = true,
            RequireExpirationTime = false,
            ValidateLifetime = true
        };
    });

var app = builder.Build();

using (var serviceScope = app.Services.CreateScope())
{
    var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<AppRole>>();
    if (!await roleManager.RoleExistsAsync("Admin"))
    {
        await roleManager.CreateAsync(new AppRole("Admin"));
    }
    if (!await roleManager.RoleExistsAsync("User"))
    {
        await roleManager.CreateAsync(new AppRole("User"));
    }
    if (!await roleManager.RoleExistsAsync("Moderator"))
    {
        await roleManager.CreateAsync(new AppRole("Moderator"));
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x.AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(origin => true).AllowCredentials());

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthentication();

app.MapControllers();

app.Run();
