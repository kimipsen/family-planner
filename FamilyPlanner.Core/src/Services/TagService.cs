using FamilyPlanner.Core.Data;
using FamilyPlanner.Core.Models;

namespace FamilyPlanner.Core.Services;

public class TagService
{
	private readonly FamilyPlannerContext _context;

	public TagService(FamilyPlannerContext context)
	{
		_context = context;
	}

	public Tag Create(string name, TagPurpose purpose)
	{
		var tag = new Tag()
		{
			Name = name,
			Purpose = purpose
		};
		_context.Tags.Add(tag);
		_context.SaveChanges();

		return tag;
	}
}