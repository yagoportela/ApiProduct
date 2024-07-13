using ProductRegistration.Api;
using ProductRegistration.Infra.CrossCutting.IoC.Configurations;
using ProductRegistration.Infra.CrossCutting.IoC.ConfigurationWebApplication;

var builder = WebApplication.CreateBuilder(args);

    //AutoMapper
    builder.Services.AddAutoMapper(x =>
    {
        x.AddProfile(new RequestToCommands());
        x.AddProfile(new RequestToNotification());
        x.AllowNullCollections = true;
        x.AllowNullCollections = true;
    });

// Add services to the container.
InjectionDependency.Injection(builder.Services);
ConfigurationBuild.Configuration(builder.Build());
