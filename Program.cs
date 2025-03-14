using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MoviesAPI.Data;
using MoviesAPI.Models;
using MoviesAPI.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var dbPath = System.IO.Path.Join(Environment.CurrentDirectory, "movie.db");
builder.Services.AddDbContext<MovieContext>(opts => opts.UseLazyLoadingProxies().UseSqlite($"Data Source={dbPath}"));
builder.Services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<MovieContext>()
                .AddDefaultTokenProviders();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddScoped<UserService>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "FilmesAPI", Version = "v1" });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

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
