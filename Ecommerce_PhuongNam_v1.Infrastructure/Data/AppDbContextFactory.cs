using Ecommerce_PhuongNam_v1.Application.Common.CurrentUserService;
using Ecommerce_PhuongNam_v1.Infrastructure.Data.Configs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Ecommerce_PhuongNam_v1.Infrastructure.Data
{
	public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
	{
		private readonly ICurrentUserService _currentUserService;

		public AppDbContextFactory()
		{
		}

		public AppDbContextFactory(ICurrentUserService currentUserService)
		{
			_currentUserService = currentUserService;
		}

		public AppDbContext CreateDbContext(string[] args)
		{
			IConfigurationRoot configuration = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
				.Build();

			var connectionString = configuration.GetConnectionString("DefaultDB");

			var optionBuilder = new DbContextOptionsBuilder<AppDbContext>();
			optionBuilder.UseSqlServer(connectionString);

			return new AppDbContext(optionBuilder.Options, _currentUserService);
		}
	}
}