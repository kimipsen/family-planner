using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FamilyPlanner.Core.Data;

public class SqlServerFamilyPlannerContextFactory : IDesignTimeDbContextFactory<SqlServerFamilyPlannerContext>
{
	public SqlServerFamilyPlannerContext CreateDbContext(string[] args)
	{
		var optionsBuilder = new DbContextOptionsBuilder<FamilyPlannerContext>();
		optionsBuilder.UseSqlServer("Server=mssql;Database=familyplanner;User Id=sa;Password=F@miLyplanner1;", o => o.UseNodaTime());

		return new SqlServerFamilyPlannerContext(optionsBuilder.Options);
	}

	public SqlServerFamilyPlannerContext CreateDbContext(string connectionString)
	{
		var optionsBuilder = new DbContextOptionsBuilder<FamilyPlannerContext>()
			.UseSqlServer(
				connectionString,
				o => o.MigrationsAssembly("FamilyPlanner.Core").UseNodaTime());
		return new SqlServerFamilyPlannerContext(optionsBuilder.Options);
	}
}