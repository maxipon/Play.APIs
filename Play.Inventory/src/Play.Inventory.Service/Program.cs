using Play.Common.MassTransit;
using Play.Common.MongoDBs;
using Play.Inventory.Service.Client;
using Play.Inventory.Service.Entities;
using Polly;
using Polly.Timeout;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddMongo().
                AddMongoRepository<InventoryItem>("inventoryItems").
                AddMongoRepository<CatalogItem>("catalogItems")
                .AddMassTransitWithRabbitMq();

//the source code of this method is at the end of this file
AddCatalogClient(builder);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

const string AllowedOriginSettings = "http://localhost:3000";

app.UseCors(builder =>
{
    builder.WithOrigins(AllowedOriginSettings)
           .AllowAnyHeader()
           .AllowAnyMethod();
});

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

static void AddCatalogClient(WebApplicationBuilder builder)
{
    Random jitterer = new Random();

    //note that the Uri IS NOT the main IPs, it's 7205
    //registering to HttpClient (so that it can be used in CatalogClient), and also adding rules, which indicates that:
    //either 5 retries (plus jitterer with exponential backoff), or throw an exception
    builder.Services.AddHttpClient<CatalogClient>(client =>
    {
        client.BaseAddress = new Uri("https://localhost:7201/");
    })
    .AddTransientHttpErrorPolicy(builder => builder.Or<TimeoutRejectedException>().WaitAndRetryAsync(
        5,
        retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
        + TimeSpan.FromMilliseconds(jitterer.Next(0, 1000))
    ))
    .AddTransientHttpErrorPolicy(builder => builder.Or<TimeoutRejectedException>().CircuitBreakerAsync(
        //how many request is allowed before Circuit Breaker take place
        3,
        //after this timespan is passed, circuit breaker will allow one more request. if it succeeds, the circuit breaker will be released
        TimeSpan.FromSeconds(15)
        ))
    .AddPolicyHandler(Policy.TimeoutAsync<HttpResponseMessage>(1));
}