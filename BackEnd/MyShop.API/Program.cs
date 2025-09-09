using MyShop.API.Extensions;

var builder = WebApplication.CreateBuilder(args);
{

    builder.Services.AddControllers();
    builder.Services.AddSwaggerGen();
    
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                           ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
    
    builder.Services.AddDbContext(connectionString);

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
app.UseAuthorization();
app.Run();
