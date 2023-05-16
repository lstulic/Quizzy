using Microsoft.EntityFrameworkCore;
using Quizzy.Helpers;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Quizzy.Repository.Data.StudentsQuizzyContext>(options =>
    options.UseLazyLoadingProxies().UseSqlServer("Data Source=softlabrsdev.database.windows.net;Initial Catalog=Students.Quizzy;User ID=Students.Quizzy.dbo;Password=6VCJ@drZX!ocoTys;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"));

var allowedWebClient = "allowedWebClient";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowedWebClient,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000",
                                                    "http://127.0.0.1:5173")
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowAnyOrigin();

                      });
});

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);



builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddAutoMapper(typeof(QuizzyProfile));


builder.Services.AddScoped<Quizzy.Core.Repositories.IUserRepository, Quizzy.Repository.Repositories.UserRepository>();
builder.Services.AddScoped<Quizzy.Core.Repositories.IQuizRepository, Quizzy.Repository.Repositories.QuizRepository>();
builder.Services.AddScoped<Quizzy.Core.Repositories.IInviteRepository, Quizzy.Repository.Repositories.InviteRepository>();
builder.Services.AddScoped<Quizzy.Core.Repositories.IScoreboardRepository, Quizzy.Repository.Repositories.ScoreboardRepository>();



builder.Services.AddScoped<Quizzy.Core.Services.IUserService, Quizzy.Service.Services.UserService>();
builder.Services.AddScoped<Quizzy.Core.Services.IQuizService, Quizzy.Service.Services.QuizService>();
builder.Services.AddScoped<Quizzy.Core.Services.IInviteService, Quizzy.Service.Services.InviteService>();
builder.Services.AddScoped<Quizzy.Core.Services.IScoreboardService, Quizzy.Service.Services.ScoreboardService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(allowedWebClient);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
