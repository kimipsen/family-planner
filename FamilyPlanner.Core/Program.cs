using FamilyPlanner.Core.Data;
using FamilyPlanner.Core.Schema;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
	.AddGraphQLServer()
	.AddQueryType<FamilyPlannerQueryRoot>()
	.AddTypeExtension<RecipeQueryRoot>();

builder.Services.AddTransient<IRecipeRepository, RecipeRepository>();

var app = builder.Build();

app.MapGraphQL();

app.Run();