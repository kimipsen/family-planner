using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FamilyPlanner.Core.Data;

public class SqliteFamilyPlannerContextFactory : IDesignTimeDbContextFactory<SqliteFamilyPlannerContext>
{
    public SqliteFamilyPlannerContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<FamilyPlannerContext>();
		optionsBuilder.UseSqlite("Data Source=database/familyplanner.db", o => o.UseNodaTime());

        return new SqliteFamilyPlannerContext(optionsBuilder.Options);
    }

    public SqliteFamilyPlannerContext CreateDbContext(string connectionString)
    {
        var optionsBuilder = new DbContextOptionsBuilder<FamilyPlannerContext>()
            .UseSqlite(
                connectionString,
                o => o.MigrationsAssembly("FamilyPlanner.Core").UseNodaTime());
        return new SqliteFamilyPlannerContext(optionsBuilder.Options);
    }
}