using FamilyPlanner.Core.Data;
using FamilyPlanner.Core.Models;

namespace FamilyPlanner.Core.Services;

public class RecipeService
{
	private readonly FamilyPlannerContext _context;

	public RecipeService(FamilyPlannerContext context)
	{
		_context = context;
	}

	public Recipe Create(string name, params int[] tagIds)
	{
		var recipe = new Recipe()
		{
			Name = name
		};
		SetTagsOnRecipe(recipe, tagIds);
		_context.Recipes.Add(recipe);
		_context.SaveChanges();

		return recipe;
	}

	public Recipe SetTags(int recipeId, params int[] tagIds)
	{
		var recipe = _context.Recipes.Single(x => x.Id == recipeId);
		recipe.Tags.Clear();
		SetTagsOnRecipe(recipe, tagIds);
		_context.SaveChanges();

		return recipe;
	}

	private void SetTagsOnRecipe(Recipe recipe, params int[] tagIds)
	{
		var tags = _context.Tags.Where(x => tagIds.Contains(x.Id));
		foreach (var tag in tags)
			recipe.Tags.Add(tag);
	}
}