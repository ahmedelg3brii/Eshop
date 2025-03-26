var builder = WebApplication.CreateBuilder(args);

//add services to the container
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

builder.Services.AddCarter();


//configure the HTTP request pipeline

var app = builder.Build();
app.MapCarter();

app.Run();

