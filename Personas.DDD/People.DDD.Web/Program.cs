using Ardalis.ListStartupServices;
using FastEndpoints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.




builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


//app.UseFastEndpoints();//ral
    //.UseSwaggerGen(); // Includes AddFileServer and static files middleware

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
  //app.UseShowAllServicesMiddleware(); // see https://github.com/ardalis/AspNetCoreStartupServices
  app.UseShowAllServicesMiddleware();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
