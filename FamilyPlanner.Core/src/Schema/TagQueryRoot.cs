using FamilyPlanner.Core.Data;
using FamilyPlanner.Core.Models;

namespace FamilyPlanner.Core.Schema;

[ExtendObjectType(typeof(FamilyPlannerQueryRoot))]
public class TagQueryRoot
{
	public IEnumerable<Tag> GetTags(FamilyPlannerContext context, TagPurpose purpose) => context.Tags.Where(x => x.Purpose == purpose);
}