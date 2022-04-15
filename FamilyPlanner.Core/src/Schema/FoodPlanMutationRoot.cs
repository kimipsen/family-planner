using FamilyPlanner.Core.Models;
using FamilyPlanner.Core.Services;
using NodaTime;

namespace FamilyPlanner.Core.Schema;

[ExtendObjectType(typeof(FamilyPlannerMutationRoot))]
public class FoodPlanMutationRoot
{
	public FoodPlan CreateFoodPlan([Service] FoodPlanService service, string name, LocalDate startDate, IsoDayOfWeek[] weekDays) => service.CreateFoodPlan(name, startDate, weekDays);
}