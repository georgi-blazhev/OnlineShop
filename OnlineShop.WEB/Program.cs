using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineShop.BLL.IServices;
using OnlineShop.BLL.Services;
using OnlineShop.DAL.Data;
using OnlineShop.DAL.Entities;
using OnlineShop.DAL.IRepository;
using OnlineShop.DAL.Repository;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

var connectionString = configuration.GetConnectionString("Default");

builder.Services.AddDbContext<DatabaseContext>(
    options => options.UseSqlServer(connectionString));


//Adding Identity Repositories
builder.Services.AddIdentity<User, IdentityRole>(config =>
{
    config.Password.RequiredLength = 4;
    config.Password.RequireDigit = false;
    config.Password.RequireUppercase = false;
    config.Password.RequireNonAlphanumeric = false;
})
                .AddEntityFrameworkStores<DatabaseContext>()
                .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(config =>
{
    config.Cookie.Name = "OnlineShopCookie";
});


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DAL
builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));


builder.Services.AddTransient<IUserManager, OnlineShopUserManager>();
builder.Services.AddTransient<ISignInManager, OnlineShopSignInManager>();


//BLL
builder.Services.AddTransient<IUserService, UserService>();

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
