var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

app.Urls.Clear();
app.Urls.Add("http://*:80");

app.UseRouting();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
