using FamilyPlanner.Core.Models;

namespace FamilyPlanner.Core.Data
{
	public interface IRecipeRepository
	{
		IEnumerable<Recipe> GetRecipes(string[] tags);
	}
}