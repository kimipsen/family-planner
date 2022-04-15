using FamilyPlanner.Core.Data;
using FamilyPlanner.Core.Models;

namespace FamilyPlanner.Core.Schema;

public class FoodPlanQueryRoot
{
	public FoodPlan GetActiveFoodPlan(FamilyPlannerContext context) => context.FoodPlans.Single(x => x.Active);
}