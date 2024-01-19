using MongoDB.Driver;
using Serilog;
using Serilog.Ex.Services;
using ILogger = Serilog.ILogger;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .CreateLogger();
//ILogger Logger = new LoggerConfiguration().MinimumLevel.Information().WriteTo.MongoDBBson(databaseUrl: "mongodb://localhost:27017/Serilogs", collectionName: "Serilogs").CreateLogger();
builder.Services.Configure<MongoDbDatabaseSetting>(
    builder.Configuration.GetSection("MongoDB"));
builder.Host.UseSerilog();
builder.Services.AddControllers();
builder.Services.AddControllersWithViews();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<SerilogsServices>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();

app.MapControllers();

try
{
    Log.Information("Application is Satrting");
    app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Serilogs}/{action=Index}"
    );
    app.Run();

}
catch (Exception ex)
{
    Log.Fatal(ex, "Failed to start");
}
finally
{
    Log.CloseAndFlush();

}

