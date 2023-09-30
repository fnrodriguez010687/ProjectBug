using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NSwag;
using ProjectBug_Entities;
using ProjectBug_Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "LocalWeb",
                      policy =>
                      {
                          policy.WithOrigins("*")
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowAnyOrigin();
                      });
});
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Database"));
});
builder.Services.AddAutoMapper(typeof(BugsMapper));
builder.Services.AddScoped<IBugServices, BugServices>();
builder.Services.AddControllers();
builder.Services.AddOpenApiDocument(options => {
    options.PostProcess = document =>
    {
        document.Info = new OpenApiInfo
        {
            Version = "v1",
            Title = "Project Bugs Web Api",
            Description = "An ASP.NET Core Web API for managing bugs in a Project",
            TermsOfService = "",
        };
    };
});
var app = builder.Build();

// Configure the HTTP request pipeline.
var task = new Task(() => UpdateDatabase(app));
task.Start();
app.UseHttpsRedirection();

app.UseCors("LocalWeb");
if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi3();
    app.UseReDoc(options =>
    {
        options.Path = "/Help";
    });
}
app.UseAuthorization();

app.MapControllers();

app.Run();

static void UpdateDatabase(WebApplication app)
{
    try
    {
        using (var serviceScope = app.Services.CreateScope())
        {
            var context = serviceScope.ServiceProvider.GetService<DataContext>();
            context.FixDatabase();
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(e.StackTrace);
    }
}
