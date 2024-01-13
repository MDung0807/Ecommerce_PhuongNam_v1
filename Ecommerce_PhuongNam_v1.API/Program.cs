

using Ecommerce_PhuongNam_v1.API.Middlewares;
using Ecommerce_PhuongNam_v1.Application;
using Ecommerce_PhuongNam_v1.Application.Common.Exceptions;
using Ecommerce_PhuongNam_v1.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddInfrastructureLayer(builder.Configuration);
builder.Services.AddApplicationLayer(builder.Configuration);
var services = builder.Services;
#region -- Authen --
JwtMiddleware.ConfigureService(services);
#endregion -- Authen --

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseRouting();
app.UseCors(options =>
{
    options.AllowAnyOrigin();
    options.AllowAnyMethod();
    options.AllowAnyHeader();
});
app.UseMiddleware<ExceptionMiddleware>();
app.UseAuthentication();
app.UseAuthorization();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseEndpoints(endpoints =>
    endpoints.MapControllers()) ;
        
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.Run();