using FamilyPlanner.Core.Models;
using FamilyPlanner.Core.Services;

namespace FamilyPlanner.Core.Schema;

[ExtendObjectType(typeof(FamilyPlannerMutationRoot))]
public class TagMutationRoot
{
	public Tag CreateTag([Service] TagService service, string name, TagPurpose purpose) => service.Create(name, purpose);
}