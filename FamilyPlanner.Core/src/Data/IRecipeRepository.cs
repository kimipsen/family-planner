using FamilyPlanner.Core.Models;

namespace FamilyPlanner.Core.Data;
public interface IRecipeRepository
{
	Recipe Create(string name, params Tag[] tags);
	IEnumerable<Recipe> GetRecipes(string[] tags);
	Recipe SetRecipeTags(int recipeId, params Tag[] tags);
}