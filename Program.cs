using FinancialRevenues.DbContexts;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using FinancialRevenues.Lookups.Seed;
using FinancialRevenues.Profile;
using FinancialRevenues.Revenues.Repositories;
using FinancialRevenues.Revenues.Services;
using FinancialRevenues.Users.Entities;
using FinancialRevenues.Users.Repositories;
using FinancialRevenues.Users.Services;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IRevenueRepository, RevenueRepository>();
builder.Services.AddTransient<IRevenueService, RevenueService>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserService, UserService>();
// Add DbContext
builder.Services.AddDbContext<FinancialRevenuesDbContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")!));
builder.Services.AddAutoMapper(typeof(CustomDtoMapper));

// Add authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
        builder.Configuration.Bind("JwtSettings", options))
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
        builder.Configuration.Bind("CookieSettings", options));

builder.Services.AddIdentity<User, IdentityRole<long>>(
        options => { options.SignIn.RequireConfirmedAccount = true; })
    .AddEntityFrameworkStores<FinancialRevenuesDbContext>()
    .AddDefaultTokenProviders();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication(); // Enable authentication middleware
app.UseAuthorization();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var dbContext = services.GetRequiredService<FinancialRevenuesDbContext>();
        await LookupBuilder.InitializeAsync(dbContext); // Call seed method
    }
    catch (Exception ex)
    {
        Console.WriteLine("An error occurred while seeding the database.");
        Console.WriteLine(ex.Message);
    }
}

app.MapControllers();

app.Run();