using FamilyPlanner.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace FamilyPlanner.Core
{
	public static class DbContextHelper
	{
		private static string ConnectionStringName = "FamilyPlanner";
		public static IServiceCollection SetupDbContext(this IServiceCollection services, IConfiguration configuration)
		{
			var provider = configuration.GetValue<Provider>("AppSettings:Provider");

			switch(provider)
			{
				case Provider.PostgreSql:
					services.AddDbContext<FamilyPlannerContext>(options =>
						options.UseNpgsql(configuration.GetConnectionString(ConnectionStringName), o => o.UseNodaTime()));

					var postgreSqlContext = new PostgreSqlFamilyPlannerContextFactory().CreateDbContext(configuration.GetConnectionString(ConnectionStringName));
					if (postgreSqlContext.Database.GetPendingMigrations().Any()) postgreSqlContext.Database.Migrate();
					break;

				case Provider.Sqlite:
					services.AddDbContext<FamilyPlannerContext>(options =>
						options.UseSqlite(configuration.GetConnectionString(ConnectionStringName), o => o.UseNodaTime()));

					var sqliteContext = new SqliteFamilyPlannerContextFactory().CreateDbContext(configuration.GetConnectionString(ConnectionStringName));
					if (sqliteContext.Database.GetPendingMigrations().Any()) sqliteContext.Database.Migrate();
					break;

				case Provider.SqlServer:
					services.AddDbContext<FamilyPlannerContext>(options =>
						options.UseSqlServer(configuration.GetConnectionString(ConnectionStringName), o => o.UseNodaTime()));

					var sqlServerContext = new SqlServerFamilyPlannerContextFactory().CreateDbContext(configuration.GetConnectionString(ConnectionStringName));
					if (sqlServerContext.Database.GetPendingMigrations().Any()) sqlServerContext.Database.Migrate();
					break;
			}

			return services;
		}
	}
}
