using calculator.Data;

namespace calculator
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			builder.Configuration.AddJsonFile("appsettings.json", false, true);
			builder.Services.AddDbContext<DataContext>();
			IConfiguration config = builder.Configuration;
			builder.Services.Add(new ServiceDescriptor(typeof(DataContext), new DataContext(config)));
			builder.Services.Add(new ServiceDescriptor(typeof(ICalculator), new Calculator((new DataContext(builder.Configuration)))));
			var provider = builder.Services.BuildServiceProvider();
			DataContext service = provider.GetService<DataContext>();
			service.Init();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}