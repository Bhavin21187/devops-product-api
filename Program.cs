var builder = WebApplication.CreateBuilder(args);

// Add controller support
builder.Services.AddControllers();

// Add Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// HTTPS will be configured later for Kubernetes
// app.UseHttpsRedirection();

app.UseAuthorization();

// Map controller routes
app.MapControllers();

app.Run();