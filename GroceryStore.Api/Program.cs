using GroceryStore.Api.Extensions;
using System.Text.Json.Serialization;

const string ALLOW_SPECIFIED_ORIGINS_POLICY = "AllowSpecifiedOrigins";
const string CLIENT_URL_SECTION_NAME = "ClientUrl";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    var clientUrl = builder.Configuration.GetSection(CLIENT_URL_SECTION_NAME).Value;
    options.AddPolicy(name: ALLOW_SPECIFIED_ORIGINS_POLICY,
        builder =>
        {
            builder.WithOrigins(clientUrl);
        });
});

builder.Services
    .AddControllers()
    .AddJsonOptions(opts =>
     {
         var enumConverter = new JsonStringEnumConverter();
         opts.JsonSerializerOptions.Converters.Add(enumConverter);
     });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(ALLOW_SPECIFIED_ORIGINS_POLICY);

app.UseAuthorization();

app.MapControllers();

app.Run();
