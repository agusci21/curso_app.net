var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Inyeccion de dependencias
builder.Services.AddScoped<IHelloWorldService, HelloWorldService>();
//builder.Services.AddScoped(p => new HelloWorldService()); Mala practica 
//builder.Services.AddScoped<IHelloWorldService>(p => new HelloWorldService(/*Algo*/)); Mejor practica 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();   //MIDLEWARES

app.UseAuthorization();

//app.useTimeMiddleware();

app.MapControllers();

app.Run();
