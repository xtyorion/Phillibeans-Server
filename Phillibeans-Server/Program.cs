using Phillibeans_Server;
using Phillibeans_Server.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(p => p.AddPolicy("corspolicy", build =>
{
    build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddSingleton(new PhillibeansDbContext());
//builder.Services.AddScoped<IRepository>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<SolutionsRepository>();
builder.Services.AddScoped<LanguageRepository>();
builder.Services.AddScoped<ChallengeTypesRepository>();
builder.Services.AddScoped<ChallengeRepository>();
builder.Services.AddScoped<ChallengeCategoriesRepository>();
builder.Services.AddScoped<UserChallengeRepository>();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("corspolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
