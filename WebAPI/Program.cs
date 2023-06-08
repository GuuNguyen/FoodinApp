using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Repositories.CityRepositories;
using Repositories.Repositories.DistrictRepositories;
using Repositories.Repositories.ImageRepositories;
using Repositories.Repositories.RestaurantRepositories;
using Repositories.Repositories.ReviewRepositories;
using Repositories.Repositories.UserRepositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FoodinAppManagementContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyDB"));
});
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRestaurantRepository, RestaurantRepository>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<IDistrictRepository, DistrictRepository>();
builder.Services.AddScoped<IImageRepository, ImageRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
