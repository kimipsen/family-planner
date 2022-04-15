namespace FamilyPlanner.Core.Models;

public class Tag
{
	public int Id { get; set; }
	public string Name { get; set; } = "";
	public TagPurpose Purpose { get; set; }
}