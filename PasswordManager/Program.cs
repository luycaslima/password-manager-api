using Microsoft.EntityFrameworkCore;
using PasswordManager.Repositories;
using PasswordManager.Repositories.DataAccess;
using PasswordManager.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddScoped<IPasswordDataService,PasswordDataService>();
builder.Services.AddScoped<IPasswordRepository,PasswordRepository>();
//builder.Services.AddScoped<AddPasswordUseCase>();


builder.Services.AddDbContext<PasswordManagerDbContext>(options =>{
    options.UseInMemoryDatabase("Passwords");
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
