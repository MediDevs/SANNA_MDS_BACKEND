using MDS.Api.Infrastructure.Helpers;
using MDS.Api.Utility.Extensions;
using MDS.DbContext.Infrastructure;
using MDS.Infrastructure.Settings;
using MDS.Services.Hub.Implementation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    options.Filters.Add(new ProducesAttribute("application/json"));
});

builder.Services.AddEndpointsApiExplorer();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
IConfiguration configuration = builder.Configuration;
IAppSettings appSettings = new AppSettings(configuration);


builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

IdentityHelper.ConfigureService(builder.Services);
AuthenticationHelper.ConfigureService(builder.Services, appSettings.Issuer, appSettings.Audience, appSettings.Key);
SwaggerHelper.ConfigureService(builder.Services);

builder.Services.AddScoped<Microsoft.EntityFrameworkCore.DbContext, ApplicationDbContext>();
builder.Services.AddUnitOfWork();
builder.Services.AddUnitOfWork<ApplicationDbContext>();

builder.Services.AutoRegisterServices();
//builder.Services.AddSignalR();
builder.Services.AddSignalR(e => {
    e.MaximumReceiveMessageSize = 102400000;
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("development", policy =>
    {
        policy.WithOrigins("http://localhost:5001")
        .WithExposedHeaders("X-Pagination")
        .AllowAnyHeader()
        .AllowCredentials()
        .WithMethods("POST", "PUT", "PATCH", "GET", "DELETE")
        .SetIsOriginAllowed(host => true);
    });

    options.AddPolicy("production", policy =>
    {
        policy.WithOrigins(appSettings.ClientBaseUrl)
        .SetIsOriginAllowed(isOriginAllowed: _ => true)
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
    });
});
var app = builder.Build();

//app.UsePathBase("/api");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Enable middleware to serve generated Swagger as a JSON endpoint.
    app.UseCors("development");
}
else 
{
    app.UseCors("production");
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
//app.UseAuthentication();
app.UseAuthorization();
//app.UseRouting();
//app.UseResponseCompression();

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//    endpoints.MapHub<HubClienteService>("/userHub");
//});

app.MapControllers();

app.MapHub<HubClienteService>("/userHub");

app.Run();
