using MyShop.API.Extensions;

var builder = WebApplication.CreateBuilder(args);
{

    builder.Services.AddControllers();
    builder.Services.AddSwaggerGen();
    
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                           ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
    
    Console.WriteLine($"Connection string: {connectionString}");

    builder.Services.AddMyDbContext(connectionString);
    
    builder.Services.AddMyAuthentication(builder.Configuration.GetSection("Jwt"));

    // Register repositories
    builder.Services.AddRepositories();
    // Register services
    builder.Services.AddServices();

    builder.Services.AddMyCors();
}

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.UseSwaggerDocumentation();

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
