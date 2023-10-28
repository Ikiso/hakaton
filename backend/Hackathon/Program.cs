using FluentValidation.AspNetCore;
using Hackathon.Dtos;
using Hackathon.Models;
using Hackathon.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddAuthorization();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    var authConf = new AuthOptionsConfig();
    builder.Configuration.GetSection("AuthOptions").Bind(authConf);

    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidIssuer = authConf.Issuer,
        ValidateAudience = true,
        ValidAudience = authConf.Audience,
        ValidateLifetime = authConf.ValidateLifetime,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authConf.Key))
    };
});

//builder.Services.AddValidatorsFromAssemblyContaining<UserLoginValidator>();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>((options) => options.UseSqlite(connectionString));
builder.Services.AddScoped<IOrganizationService, OrganizationService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IEducationalMaterialService, EducationalMaterialService>();
builder.Services.AddScoped<IUserService, UserService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
