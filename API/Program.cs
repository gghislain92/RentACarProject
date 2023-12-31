using Business.Abstracts;
using Business.Concretes;
using Data_Access.Abstracts;
using Data_Access.Concretes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IModelService, ModelManager>();
builder.Services.AddScoped<IModelDal, ModelDal>();
builder.Services.AddScoped<IBrandService, BrandManager>();
builder.Services.AddScoped<IBrandDal, BrandDal>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
