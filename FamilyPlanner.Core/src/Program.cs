using FamilyPlanner.Core;
using FamilyPlanner.Core.Data;
using FamilyPlanner.Core.Schema;
using FamilyPlanner.Core.Services;
using HotChocolate.Types.NodaTime;
using NodaTime;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.SetupDbContext(builder.Configuration);
builder.Services
	.AddGraphQLServer()
	.RegisterDbContext<FamilyPlannerContext>()
	.AddQueryType<FamilyPlannerQueryRoot>()
	.AddTypeExtension<RecipeQueryRoot>()
	.AddTypeExtension<TagQueryRoot>()
	.AddTypeExtension<FoodPlanQueryRoot>()
	.AddMutationType<FamilyPlannerMutationRoot>()
	.AddTypeExtension<RecipeMutationRoot>()
	.AddTypeExtension<TagMutationRoot>()
	.AddTypeExtension<FoodPlanMutationRoot>()
	.AddType<LocalDateType>();

// builder.Services.AddTransient<FamilyPlannerContext>();
builder.Services.AddTransient<TagService>();
builder.Services.AddTransient<RecipeService>();
builder.Services.AddTransient<FoodPlanService>();
builder.Services.AddSingleton<IClock>(SystemClock.Instance);

var app = builder.Build();

using (var scope = app.Services.GetService<IServiceScopeFactory>().CreateScope())
{
	scope.ServiceProvider.GetRequiredService<FamilyPlannerContext>().Migrate();
}

app.MapGraphQL();

app.Run();