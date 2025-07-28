var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpClient("ProviderClient",client =>
{
    client.BaseAddress = new Uri("http://weatherproviderapi:80/");  ///    http://localhost:5186
});

var app = builder.Build();

app.Urls.Clear();
app.Urls.Add("http://*:80");
app.UseRouting();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
