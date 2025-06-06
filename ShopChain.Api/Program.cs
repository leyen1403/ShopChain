using ShopChain.Api;

var builder = WebApplication.CreateBuilder(args);

// Đăng ký các service DI theo tầng
builder.Services.AddAppDI(builder.Configuration);

// Đăng ký controller + Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware pipeline
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
