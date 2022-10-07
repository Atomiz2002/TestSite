using TestSite.Core.Contracts;
using TestSite.Core.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options => {
	options.SwaggerDoc("v1", new() {
		Title       = "My Test Site",
		Description = "Its amazing tbh",
		License = new() {
			Name = "EULA idk"
		}
	});

	options.IncludeXmlComments("bin/Debug/TestSite.Api.xml");
});

builder.Services.AddScoped<IPlayerService, PlayerService>();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment()) {
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();