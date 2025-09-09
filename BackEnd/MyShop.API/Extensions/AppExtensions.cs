namespace MyShop.API.Extensions;

public static class AppExtensions
{
    public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Doc API v1");
            c.RoutePrefix = string.Empty;
        });

        return app;
    }
}