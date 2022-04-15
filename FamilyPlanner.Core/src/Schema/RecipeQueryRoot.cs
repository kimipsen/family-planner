using FamilyPlanner.Core.Data;
using FamilyPlanner.Core.Models;

namespace FamilyPlanner.Core.Schema;

[ExtendObjectType(typeof(FamilyPlannerQueryRoot))]
public class RecipeQueryRoot
{
	public IEnumerable<Recipe> GetRecipes([Service] IRecipeRepository recipeRepository, string[] tags) => recipeRepository.GetRecipes(tags);
}