using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Thunders.TechTest.ApiService;
using Thunders.TechTest.Application.Commands.Toll;
using Thunders.TechTest.Application.Handlers.Toll;
using Thunders.TechTest.Domain.Repositories;
using Thunders.TechTest.infrastructure;
using Thunders.TechTest.infrastructure.Repositories;
using Thunders.TechTest.OutOfBox.Queues;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();


var features = Features.BindFromConfiguration(builder.Configuration);

// Add services to the container.
builder.Services.AddProblemDetails();

//IOC
builder.Services.AddTransient<TollCommandHandler>();
builder.Services.AddTransient<TollQueryHandler>();

builder.Services.AddTransient<ITollRepository, TollRepository>();

//Validators Toll
builder.Services.AddScoped<IValidator<CreateTollCommand>, CreateTollValidator>();
builder.Services.AddScoped<IValidator<UpdateTollCommand>, UpdateTollValidator>();
builder.Services.AddScoped<IValidator<DeleteTollCommand>, DeleteTollValidator>();

if (features.UseMessageBroker)
{
    builder.Services.AddBus(builder.Configuration, new SubscriptionBuilder());
}

if (features.UseEntityFramework)
{
    builder.Services.AddDbContext<DefaultContext>((options) =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString("ThundersTechTestDbPostgres"),                    
            b => b.MigrationsAssembly("Thunders.TechTest.infrastructure")
        );
    });
}


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

app.MapDefaultEndpoints();

app.MapControllers();

app.Run();
