using ProductRegistration.Infra.CrossCutting.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
InjectionDependency.Injection(builder.Services);
ConfigurationBuild.Configuration(builder.Build());
