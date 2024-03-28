using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using DIsample;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.AddHostedService<Worker>();
//builder.Services.AddSingleton<IMessageWriter, MessageWriter>();
builder.Services.AddSingleton<IMessageWriter, LoggingMessageWriter>();


using IHost host = builder.Build();

host.Run();