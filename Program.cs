using Microsoft.EntityFrameworkCore;
using MovieAPI.DB;
using MovieAPI.Interface;
using MovieAPI.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var Connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Connection));
builder.Services.AddScoped<ICinema, CinemaRepo>();
builder.Services.AddScoped<IMovie, MovieRepo>();
builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.UseAuthorization();

app.MapControllers();

app.Run();