using CustomMediator.Api.Example;
using CustomMediator.Library;
using CustomMediator.Library.Abstractions;
using CustomMediator.Library.Concretes;
using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCustomMediator(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IMediator,Mediator>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/",async (IMediator mediator) =>
{
    var result = await mediator.Send(new GetUserByIdQuery(1));
   return result;
});

app.Run();