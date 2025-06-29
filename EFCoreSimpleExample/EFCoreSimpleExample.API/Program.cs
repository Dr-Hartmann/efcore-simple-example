using EFCoreSimpleExample.Application.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// ����������� ��������� � �������/DI ��� ������� �������� ������������
builder.Services.AddDbContext<ApplicationDbContext>();

// Swagger
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // Swagger
    app.MapOpenApi();
}

//app.UseAuthorization();
//app.UseAuthentication();
app.MapControllers();

app.Run();
