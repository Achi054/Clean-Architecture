using Clean.Architecture.Persistence;
using Clean.Architecture.Persistence.Interceptors;

using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Register MediatR settings
builder.Services.AddMediatR(ctx =>
    ctx.RegisterServicesFromAssemblies(Clean.Architecture.Application.AssemblyReference.Assembly));

// Register Database settings
var connectionString = builder.Configuration.GetConnectionString("Database");

builder.Services.AddSingleton<ConvertDomainEventToOutboxMessage>();

builder.Services.AddDbContext<ApplicationDbContext>((sp, optionBuilder) =>
{
    var interceptor = sp.GetRequiredService<ConvertDomainEventToOutboxMessage>();

    optionBuilder.UseSqlServer(connectionString)
        .AddInterceptors(interceptor);
});

// Add services to the container.
builder.Services
    .AddControllers()
    .AddApplicationPart(Clean.Architecture.Presentation.AssemblyReference.Assembly);

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

app.Run();
