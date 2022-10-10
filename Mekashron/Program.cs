var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<MekashronService.ICUTechClient>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("localhost", builder =>
    {
        builder
        .SetIsOriginAllowed(x => true)
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("localhost");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

