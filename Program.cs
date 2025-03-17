using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MoviesAPI.Authorization;
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
builder.Services.AddScoped<TokenService>();

// Authentication
builder.Services.AddAuthentication(opt =>{ opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("9ASHDA98H9ah9ha9H9A89n0fasdasdasdasdadadasdasdsadassasdasdsadasdsadasdsad")),
        ValidateAudience = false,
        ValidateIssuer = false,
        ClockSkew = TimeSpan.Zero
    };
});

// Authorization
builder.Services.AddSingleton<IAuthorizationHandler, AgeAuthorization>();
builder.Services.AddAuthorization(opt => 
{
    opt.AddPolicy("MinimumAge", p => p.AddRequirements(new MinimumAge(18)));
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MoviesAPI", Version = "v1" });
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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
