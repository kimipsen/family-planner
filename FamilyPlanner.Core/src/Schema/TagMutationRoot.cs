using FamilyPlanner.Core.Data;
using FamilyPlanner.Core.Models;

namespace FamilyPlanner.Core.Schema;

[ExtendObjectType(typeof(FamilyPlannerMutationRoot))]
public class TagMutationRoot
{
	public Tag CreateTag([Service] ITagRepository tagRepository, string name, TagPurpose purpose) => tagRepository.Create(name, purpose);
}