using Explorer.API.Startup;
using Explorer.Tours.Infrastructure;
using MedicalEquipmentCompany;
using MedicalEquipmentCompany.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
const string corsPolicy = "_corsPolicy";
builder.Services.ConfigureCors(corsPolicy);
builder.Services.ConfigureAuth();
builder.Services.AddDbContext<ApplicationDbContext>(
    o => o.UseNpgsql(builder.Configuration.GetConnectionString("MedicalEquipmentCompanyDb"))
);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureSwagger(builder.Configuration);

builder.Services.ConfigureModule();
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseRouting();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseCors(corsPolicy);
app.UseHttpsRedirection();

// Enable authorization if needed
app.UseAuthorization();

// Use WebSockets
app.UseWebSockets();

// Map the SignalR hub
//app.MapHub<MessageHub>("/messageHub");

app.UseEndpoints(endpoints =>
{
    // Map the SignalR hub again, if needed
    endpoints.MapHub<MessageHub>("/messageHub");

    endpoints.MapControllerRoute(
        name: "verifyEmail",
        pattern: "verifyemail",
        defaults: new { controller = "AuthenticationController", action = "VerifyEmail" });
});

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.RoutePrefix = "swagger";
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API");
});

app.Run();
