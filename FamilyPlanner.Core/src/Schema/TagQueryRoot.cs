using System.Collections;
using FamilyPlanner.Core.Data;
using FamilyPlanner.Core.Models;

namespace FamilyPlanner.Core.Schema;

[ExtendObjectType(typeof(FamilyPlannerQueryRoot))]
public class TagQueryRoot
{
	public IEnumerable<Tag> GetTags([Service] ITagRepository tagRepository, TagPurpose purpose) => tagRepository.GetTags(purpose);
}