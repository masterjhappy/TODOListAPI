using TODOListAPI.Application.Interface;
using TODOListAPI.Application.Service;
var MyAllowedOrigins = "_myAllowedOrigins";

var builder = WebApplication.CreateBuilder(args);
var allowedOrigins = builder.Configuration.GetSection("CORS:AllowedOrigins").Get<string>() ?? string.Empty;

builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSingleton<ITodoService, TodoService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowedOrigins,
                      policy =>
                      {
                          policy.WithOrigins(allowedOrigins) 
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                      });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseCors(MyAllowedOrigins);
app.UseAuthorization();

app.MapControllers();

app.Run();
