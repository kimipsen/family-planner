using FamilyPlanner.Core.Data;
using FamilyPlanner.Core.Models;

namespace FamilyPlanner.Core.Schema;

[ExtendObjectType(typeof(FamilyPlannerQueryRoot))]
public class RecipeQueryRoot
{
	public IEnumerable<Recipe> GetRecipes(FamilyPlannerContext context, string[] tags) => context.Recipes.Where(r => r.Tags.Any(t => tags.Contains(t.Name)));
}