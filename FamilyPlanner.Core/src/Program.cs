using FamilyPlanner.Core.Data;
using FamilyPlanner.Core.Schema;
using FamilyPlanner.Core.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<FamilyPlannerContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("FamilyPlanner"), o => o.UseNodaTime()));
builder.Services
	.AddGraphQLServer()
	.RegisterDbContext<FamilyPlannerContext>()
	.AddQueryType<FamilyPlannerQueryRoot>()
	.AddTypeExtension<RecipeQueryRoot>()
	.AddTypeExtension<TagQueryRoot>()
	.AddMutationType<FamilyPlannerMutationRoot>()
	.AddTypeExtension<RecipeMutationRoot>()
	.AddTypeExtension<TagMutationRoot>();

// builder.Services.AddTransient<FamilyPlannerContext>();
builder.Services.AddTransient<TagService>();
builder.Services.AddTransient<RecipeService>();
builder.Services.AddTransient<FoodPlanService>();

var app = builder.Build();

using (var scope = app.Services.GetService<IServiceScopeFactory>().CreateScope())
{
	scope.ServiceProvider.GetRequiredService<FamilyPlannerContext>().Migrate();
}

app.MapGraphQL();

app.Run();