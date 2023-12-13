
using Cart.API.Repository;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn moregit about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddStackExchangeRedisCache(options =>
{
    // options.Configuration = builder.Configuration["AppSetting:RedisConnection"];
    // options.InstanceName = builder.Configuration["AppSetting:RedisInstanceName"];

    options.Configuration = "https://reimagined-parakeet-4g9gv777vrvh77v5-9002.app.github.dev/";
    options.InstanceName = "SampleInstance";


});
builder.Services.AddScoped<ICartRepository, CartRepository>();

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
