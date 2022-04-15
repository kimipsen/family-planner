using FamilyPlanner.Core.Data;
using FamilyPlanner.Core.Models;
using NodaTime;

namespace FamilyPlanner.Core.Services;

public class FoodPlanService
{
	private readonly FamilyPlannerContext _context;

	public FoodPlanService(FamilyPlannerContext context)
	{
		_context = context;
	}

	public FoodPlan CreateFoodPlan(string name, LocalDate startDate)
	{
		var foodplan = new FoodPlan()
		{
			Name = name,
			StartDate = startDate
		};
		_context.FoodPlans.Add(foodplan);
		_context.SaveChanges();
		return foodplan;
	}
}