using FundTracrkAPI.Extantions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services
	.AddServices(builder.Configuration)
	.AddIdentityServices(builder.Configuration);
	

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod()
	.WithOrigins("http://localhost:4200"));

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
