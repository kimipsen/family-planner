namespace FamilyPlanner.Core.Models
{
	public class Recipe
	{
		public int Id { get; set; }
		public string Name { get; set; } = "";
		public ICollection<Tag> Tags { get; set; } = new List<Tag>();
	}
}