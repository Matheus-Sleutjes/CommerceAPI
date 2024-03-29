using Commerce.API.Configuration;
using Commerce.Application.Contract;
using Commerce.Application.Service;
using Commerce.Infrastructure.Context;
using Commerce.Infrastructure.Contract;
using Commerce.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IProdutoService, ProdutoService>();
builder.Services.AddTransient<IProdutoRepository, ProdutoRepository>();

//Context 
builder.Services.AddDbContext<CommerceContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

var serviceScope = app.Services.GetService<IServiceScopeFactory>().CreateScope();
var context = serviceScope.ServiceProvider.GetRequiredService<CommerceContext>();
context.Database.Migrate();
context.MigrateScripts("Script");


// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
