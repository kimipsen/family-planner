using System.Collections.Generic;
using FamilyPlanner.Core.Models;

namespace FamilyPlanner.Core.Data;

public class TagRepository : ITagRepository
{
	private readonly IFamilyPlannerContext _context;

	public TagRepository(IFamilyPlannerContext context)
	{
		_context = context;
	}

	public Tag Create(string name, TagPurpose purpose)
	{
		var entity = new Tag()
		{
			Name = name,
			Purpose = purpose
		};
		_context.Tags.Add(entity);
		_context.SaveChanges();
		return entity;
	}

	public IEnumerable<Tag> GetTags(TagPurpose purpose) => _context.Tags.Where(x => x.Purpose == purpose);
}