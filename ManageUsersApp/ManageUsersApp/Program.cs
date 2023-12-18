var builder = WebApplication.CreateBuilder(args);
var allowOrigins = "_allowOrigins"; // needed for front end and back to look at api 
// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200",
                                              "https://localhost:7292/api");
                      });
});




builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(allowOrigins); // needed for front end and back to look at api 

app.UseAuthorization();

app.MapControllers();

app.Run();
