using MongoDB.Driver;
using MongoDbLogService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    var frontend_url = builder.Configuration.GetValue<string>("frontend_url");
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins(frontend_url)
            .AllowAnyMethod()
            .AllowAnyHeader()
            .WithExposedHeaders(new string[] { "totalAmountOfRecords" });
        });
});

builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(builder.Configuration.GetValue<string>("MongoDb:ConnectionString")));

builder.Services.AddScoped<IMongoLogService, MongoLogService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseCors(option => option.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.Run();
