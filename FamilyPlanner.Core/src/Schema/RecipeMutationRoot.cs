using FamilyPlanner.Core.Models;
using FamilyPlanner.Core.Services;

namespace FamilyPlanner.Core.Schema;

[ExtendObjectType(typeof(FamilyPlannerMutationRoot))]
public class RecipeMutationRoot
{
	public Recipe CreateRecipe([Service] RecipeService service, string name, params int[] tagIds) => service.Create(name, tagIds);
}