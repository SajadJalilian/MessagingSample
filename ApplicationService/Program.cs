using ApplicationService.Common;
using ApplicationService.Features;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddConfiguredMassTransit(builder.Configuration);
builder.Services.ConfigureValidator();
builder.Services.ConfigureNotificationFeature();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler();
}

app.UseHttpsRedirection();
app.MapCongestionFeatures();

app.Run();
