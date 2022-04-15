using FamilyPlanner.Core.Data;
using FamilyPlanner.Core.Models;

namespace FamilyPlanner.Core.Schema;

[ExtendObjectType(typeof(FamilyPlannerQueryRoot))]
public class FoodPlanQueryRoot
{
	public FoodPlan? GetFoodPlan(FamilyPlannerContext context, int id) => context.FoodPlans.SingleOrDefault(x => x.Id == id);
	public FoodPlan? GetActiveFoodPlan(FamilyPlannerContext context) => context.FoodPlans.SingleOrDefault(x => x.Active);
}