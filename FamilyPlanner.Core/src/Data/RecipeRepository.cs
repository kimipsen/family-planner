using System.Linq;
using System.Security;
using FamilyPlanner.Core.Models;

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

	public Recipe Create(string name, params Tag[] tags)
	{
		var entity = new Recipe()
		{
			Name = name
		};
		foreach (var tag in tags)
			entity.Tags.Add(tag);
		_context.Recipes.Add(entity);
		_context.SaveChanges();
		return entity;
	}

	public Recipe SetRecipeTags(int recipeId, params Tag[] tags)
	{
		var entity = _context.Recipes.Single(x => x.Id == recipeId);
		entity.Tags.Clear();
		foreach (var tag in tags)
			entity.Tags.Add(tag);
		_context.SaveChanges();
		return entity;
	}
}
