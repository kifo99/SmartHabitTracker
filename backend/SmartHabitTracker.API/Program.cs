using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SmartHabitTracker.API.Data;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAuthentication()
.AddJwtBearer("Bearer", jwtOptions =>
{
    var jwtConfig = builder.Configuration.GetSection("Jwt");
    var key = jwtConfig["Key"] ?? throw new Exception("JWT key missing");
    var issuer = jwtConfig["Issuer"] ?? throw new Exception("JWT issuer missing");
    var audience = jwtConfig["Audience"] ?? throw new Exception("JWT audience missing");

    jwtOptions.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,


        ValidIssuer = issuer,
        ValidAudience = audience, 
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
    };
});


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOpenApi();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
