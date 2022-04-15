using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FamilyPlanner.Core.Data;

public class SqliteFamilyPlannerContextFactory : IDesignTimeDbContextFactory<SqliteFamilyPlannerContext>
{
    public SqliteFamilyPlannerContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<FamilyPlannerContext>();
        optionsBuilder.UseSqlite("Data Source=database/familyplanner.db");

        return new SqliteFamilyPlannerContext(optionsBuilder.Options);
    }

    public SqliteFamilyPlannerContext CreateDbContext(string connectionString)
    {
        var optionsBuilder = new DbContextOptionsBuilder<FamilyPlannerContext>()
            .UseSqlite(
                connectionString,
                b => b.MigrationsAssembly("FamilyPlanner.Core"));
        return new SqliteFamilyPlannerContext(optionsBuilder.Options);
    }
}