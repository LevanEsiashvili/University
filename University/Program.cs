using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using University.Domain.Contracts;
using University.Domain.Contracts.Repositories;
using University.Infrastructure;
using University.Infrastructure.Database;
using University.Infrastructure.Repories;
using University.WebApi.Extenstions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
builder.Services.AddJwtAndExternalAuthentication(builder.Configuration);
builder.Services.AddDbContext<UniversityDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("UniversityDbContext")));
builder.Services.AddScoped<RepositoryProvider>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IExamRepository, ExamRepository>();
builder.Services.AddScoped<IFacultyRepository, FacultyRepository>();
builder.Services.AddScoped<ILecturerRepository, LecturerRepository>();  
builder.Services.AddScoped<ILecturerSubjectRepository, LecturerSubjectRepository>();
builder.Services.AddScoped<IStudentSubjectExamRepository, StudentSubjectExamRepository>();
builder.Services.AddScoped<IStudentSubjectRepository, StudentSubjectRepository>();
builder.Services.AddScoped<ISubjectProgramRepository, SubjectProgramRepository>();
builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
builder.Services.AddScoped<IUserRepository,UserRepository>();

builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();


app.MapControllers();

app.Run();
