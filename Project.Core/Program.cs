using Project.Core.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddConfiguration();
builder.AddDatabase();
builder.AddRepository();
builder.AddHandlers();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configura��o do CORS para acesso a qualquer tipo de chamada externa.
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

//app.UseAuthorization();

// Ativa��o da configura��o do cors acima
app.UseCors();

app.MapControllers();

app.Run();
