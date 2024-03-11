using Play.Catalog.Services.Entities;
using Play.Common.MassTransit;
using Play.Common.MongoDBs;
using Play.Common.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(options =>
{
    options.SuppressAsyncSuffixInActionNames = false;
});

ServiceSettings serviceSettings;

//I changed how we can init Mongo, MongoDB and its services in Settings/Extension (it's now in Play.Common package).

serviceSettings = builder.Configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>();

builder.Services.AddMongo().AddMongoRepository<Item>("items").AddMassTransitWithRabbitMq();

//the below is not needed anymore, I have packed them all in Play.Common
//builder.Services.AddMassTransit(x =>
//{
//    x.UsingRabbitMq((context, configurator) =>
//    {
//        var rabbitMQSettings = builder.Configuration.GetSection(nameof(RabbitMQSettings)).Get<RabbitMQSettings>();
//        configurator.Host(rabbitMQSettings.Host);
//        configurator.ConfigureEndpoints(context, new KebabCaseEndpointNameFormatter(serviceSettings.ServiceName, false));
//    });
//});

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