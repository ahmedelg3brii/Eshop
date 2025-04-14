using BuildingBlocks.Behavior;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

//add services to the container
var assembly = typeof(Program).Assembly;

builder.Services.AddMediatR(config =>
{

    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
   


});
builder.Services.AddValidatorsFromAssembly(assembly); //validation layer in  mediatR

builder.Services.AddCarter();


builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);

});

builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();



//configure the HTTP request pipeline

var app = builder.Build();
app.MapCarter();

app.Run();

