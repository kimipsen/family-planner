using FamilyPlanner.Core.Data;
using FamilyPlanner.Core.Schema;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<FamilyPlannerContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("FamilyPlanner")));
builder.Services
	.AddGraphQLServer()
	.AddQueryType<FamilyPlannerQueryRoot>()
	.AddTypeExtension<RecipeQueryRoot>();

builder.Services.AddTransient<IFamilyPlannerContext, FamilyPlannerContext>();
builder.Services.AddTransient<IRecipeRepository, RecipeRepository>();

var app = builder.Build();

using (var scope = app.Services.GetService<IServiceScopeFactory>().CreateScope())
{
	scope.ServiceProvider.GetRequiredService<IFamilyPlannerContext>().Migrate();
}

app.MapGraphQL();

app.Run();