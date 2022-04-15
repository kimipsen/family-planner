using System.Collections;
using FamilyPlanner.Core.Models;

namespace FamilyPlanner.Core.Data;

public interface ITagRepository
{
	Tag Create(string name, TagPurpose purpose);
	IEnumerable<Tag> GetTags(TagPurpose purpose);
}