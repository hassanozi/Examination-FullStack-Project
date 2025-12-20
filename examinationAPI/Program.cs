using System.Diagnostics;
using System.Text;
using AutoMapper;
using examinationAPI.Data;
using examinationAPI.DTOs.Courses;
using examinationAPI.Helpers;
using examinationAPI.MiddleWares;
using examinationAPI.Repositories;
using examinationAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<Context>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
    .LogTo(log => Debug.WriteLine(log))
    .EnableSensitiveDataLogging(true);
});

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<CourseService>();
builder.Services.AddScoped<ExamService>();
builder.Services.AddScoped<QuestionService>();

builder.Services.AddAutoMapper(typeof(CourseProfile).Assembly);


builder.Services.AddScoped<GlobalErrorHandlerMiddleware>();
builder.Services.AddScoped<TransactionMiddleware>();


var key = Encoding.ASCII.GetBytes(Constants.SecretKey);

builder.Services.AddAuthentication(opt => opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
        opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(key),
            ValidIssuer = "ExaminationSystem",
            ValidAudience = "FrontEnd_ExaminationSystem",

            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            // ValidIssuer = builder.Configuration["JWT:ValidateIssuer"],
            // ValidAudience = builder.Configuration["JWT:ValidAudience"],
            // IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
        };
    });

builder.Services.AddAuthorization();


var app = builder.Build();

app.UseMiddleware<GlobalErrorHandlerMiddleware>();
app.UseMiddleware<TransactionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

MapperHelper.Mapper = app.Services.GetService<IMapper>();

app.MapControllers();

try
{
    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<Context>();
    await context.Database.MigrateAsync();
}
catch (Exception ex)
{
Console.WriteLine($"Error during startup: {ex.Message}\nStackTrace: {ex.StackTrace}\nInnerException: {ex.InnerException?.Message}");    throw;
}


app.Run();
