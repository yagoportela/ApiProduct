using ProductRegistration.Infra.CrossCutting.IoC.Configurations;
using ProductRegistration.Infra.CrossCutting.IoC.ConfigurationWebApplication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
InjectionDependency.Injection(builder.Services);
ConfigurationBuild.Configuration(builder.Build());
