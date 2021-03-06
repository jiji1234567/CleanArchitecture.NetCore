using Microsoft.AspNetCore.Mvc.Formatters;
using MyLibrary.API.Services;
using MyLibrary.API.Services.MockRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddScoped<IAuthorRepository, AuthorMockRepository>();
builder.Services.AddScoped<IBookRepository, BookMockRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddMvc(configure =>
{
    configure.ReturnHttpNotAcceptable = false;
    configure.OutputFormatters.Add(new XmlSerializerOutputFormatter());
});

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
