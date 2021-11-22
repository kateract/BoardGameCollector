using BoardGameCollector.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var client = new UPCItemDb.UPCItemDBClient(UPCItemDb.UPCItemDBEnvironment.Trial);
builder.Services.AddSingleton<UPCItemDb.UPCItemDBClient>(client);
builder.Services.AddSingleton<IUpcLookupService,UpcLookupService>();
builder.Services.AddLogging();

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

app.Run();
