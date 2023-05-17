using Acl.Configurations;
using Application.UseCases.GetGroupByUuid;
using Application.UseCases.GetGroupByUuid.Abstracts;
using Application.UseCases.GetGroups;
using Application.UseCases.GetGroups.Abstracts;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using WebApi.Configurations;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Default");

// Add services to the container.

builder.Services
    .AddControllers(setup =>
    {
        setup.Conventions.Add(new RouteTokenTransformerConvention(new SlugifyParameterTransformer()));
    })
    .AddJsonOptions(setup =>
    {
        setup.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        setup.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });
builder.Services
    .AddApiVersioning(setup =>
    {
        setup.DefaultApiVersion = new ApiVersion(1, 0);
        setup.AssumeDefaultVersionWhenUnspecified = true;
        setup.ReportApiVersions = true;
        setup.ApiVersionReader = ApiVersionReader
            .Combine(new UrlSegmentApiVersionReader(), new HeaderApiVersionReader("x-api-version"), new MediaTypeApiVersionReader("x-api-version"));
    })
    .AddVersionedApiExplorer(setup =>
    {
        setup.GroupNameFormat = "'v'VVV";
        setup.SubstituteApiVersionInUrl = true;
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<CommonContext>(setup => setup.UseSqlServer(connectionString));

builder.Services.AddScoped<IGetGroupByUuidUseCase, GetGroupByUuidUseCase>();
builder.Services.AddScoped<IGetGroupsUseCase, GetGroupsUseCase>();

var app = builder.Build();
var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(setup =>
    {
        foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions.Reverse())
            setup.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
