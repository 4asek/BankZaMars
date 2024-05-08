using Microsoft.EntityFrameworkCore;
using WebApplication2.Controller.Services.Contracts;
using WebApplication2.Controller.Services.Servic1;
using WebApplication2.Controllers.Services.Contraxts;
using WebApplication2.Data;
using WebApplication2.Data.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICustomerServices, CustomerServices>();

builder.Services.AddScoped<IEmployeeServices, EmployeeServices>();

builder.Services.AddScoped<ICardSevices, CardService>();
builder.Services.AddScoped<IAccountServices, AccountService>();
builder.Services.AddScoped<ITransactionServices, TransactionService>();

//Here changes
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
}
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// app.UseAuthentication();
// app.UseAuthorization();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
