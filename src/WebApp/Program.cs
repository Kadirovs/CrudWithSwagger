using Application.Contracts;
using Infrastructure.DataAccess;
using Infrastructure.Implementations;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(x
    => x.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IMentorService, MentorService>();
builder.Services.AddControllers(); 
builder.Services.AddSwaggerGen();
WebApplication app = builder.Build();

app.MapGet("/datetime", () => DateTime.Now);
app.MapGet("/datetimeoffset", () => DateTimeOffset.Now);

app.UseSwagger();
app.UseSwaggerUI(); 
app.MapControllers();  
app.Run();

