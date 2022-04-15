using NodaTime;

namespace FamilyPlanner.Core.Models;

public class FoodPlan
{
	public int Id { get; set; }
	public string Name { get; set; } = "";
	public string Description { get; set; } = "";
	public LocalDate StartDate { get; set; }
	public LocalDate? EndDate { get; set; }
	public IsoDayOfWeek WeekDays { get; set; }
	public int DurationInWeeks { get; set; } = 1;
	public bool Repeat { get; set; } = false;
	public bool Active { get; set; } = false;
}