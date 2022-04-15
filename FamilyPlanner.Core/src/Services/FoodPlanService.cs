using FamilyPlanner.Core.Data;
using FamilyPlanner.Core.Models;
using Microsoft.AspNetCore.Authentication;
using NodaTime;

namespace FamilyPlanner.Core.Services;

public class FoodPlanService
{
	private readonly FamilyPlannerContext _context;
	private readonly IClock _clock;

	public FoodPlanService(FamilyPlannerContext context, IClock clock)
	{
		_context = context;
		_clock = clock;
	}

	public FoodPlan CreateFoodPlan(string name, LocalDate startDate, IsoDayOfWeek[] weekDays)
	{
		var foodplan = new FoodPlan()
		{
			Name = name,
			StartDate = startDate,
			WeekDays = weekDays,
		};

		// source: https://nodatime.org/2.2.x/userguide/type-choices
		var currentDate = _clock.GetCurrentInstant().InUtc().LocalDateTime.Date;
		if (startDate < currentDate)
		{
			// disable/un-activate currently active food plan and set end date
			var currentlyActive = _context.FoodPlans.SingleOrDefault(x => x.Active);
			if (currentlyActive != null)
			{
				currentlyActive.Active = false;
				currentlyActive.EndDate = currentDate;
			}
			foodplan.Active = true;
		}
		_context.FoodPlans.Add(foodplan);
		_context.SaveChanges();
		return foodplan;
	}
}