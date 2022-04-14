using FamilyPlanner.Core.Models;
using System.Linq;

namespace FamilyPlanner.Core.Data;
public class RecipeRepository : IRecipeRepository
{
	private readonly IFamilyPlannerContext _context;

	public RecipeRepository(IFamilyPlannerContext context)
	{
		_context = context;
	}
	public IEnumerable<Recipe> GetRecipes(string[] tags)
	{
		return _context.Recipes.Where(r => r.Tags.Any(t => tags.Contains(t.Name)));
	}
}
