
using BuildingBlocks.Behaviors;

var builder = WebApplication.CreateBuilder(args);

//add services to the container
var assembly = typeof(Program).Assembly;

builder.Services.AddMediatR(config =>
{
    //here we inject at mediatR pipeline
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));



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

builder.Services.AddExceptionHandler<CustomExceptionHandler>();

//configure the HTTP request pipeline

var app = builder.Build();
app.MapCarter();
app.UseExceptionHandler((opt => { })); 
app.Run();

