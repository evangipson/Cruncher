using API.Endpoints;
using API.Serializers;
using Application.Services;

var builder = WebApplication.CreateSlimBuilder(args);

// Add HTTPS (due to the use of slim builder)
builder.WebHost.UseKestrelHttpsConfiguration();

// Add required JSON serializers (due to the use of slim builder)
builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
});

// Add all services to the builder
builder.Services
    .AddOpenApi()
    .AddKeyedSingleton<IMonsterService, MonsterService>("monsterService");

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Add all endpoints into the application
app.AddMonsterEndpoints();

app.Run();