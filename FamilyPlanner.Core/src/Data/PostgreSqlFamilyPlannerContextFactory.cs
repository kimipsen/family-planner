using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FamilyPlanner.Core.Data;

public class PostgreSqlFamilyPlannerContextFactory : IDesignTimeDbContextFactory<PostgreSqlFamilyPlannerContext>
{
	public PostgreSqlFamilyPlannerContext CreateDbContext(string[] args)
	{
		var optionsBuilder = new DbContextOptionsBuilder<FamilyPlannerContext>();
		optionsBuilder.UseNpgsql("Server=db;Port=5432;Database=postgres;User Id=postgres;Password=postgres;");

		return new PostgreSqlFamilyPlannerContext(optionsBuilder.Options);
	}

	public PostgreSqlFamilyPlannerContext CreateDbContext(string connectionString)
	{
		var optionsBuilder = new DbContextOptionsBuilder<FamilyPlannerContext>()
			.UseNpgsql(
				connectionString,
				b => b.MigrationsAssembly("FamilyPlanner.Core"));
		return new PostgreSqlFamilyPlannerContext(optionsBuilder.Options);
	}
}