using Labrasa.API.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddEFConfigurations(builder.Configuration);
builder.Services.AddDependencyInjection();

var app = builder.Build();

app.AddPipelineConfiguration(builder.Environment);

app.MapControllers();

app.Run();