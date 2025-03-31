using UserManagementAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseMiddleware<TokenValidationMiddleware>();
app.UseMiddleware<RequestResponseLoggingMiddleware>();

app.UseHttpsRedirection();
app.UseAuthorization();




app.MapControllers();

app.Run();