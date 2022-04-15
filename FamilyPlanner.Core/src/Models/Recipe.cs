using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using System.Security.Policy;

namespace FamilyPlanner.Core.Models
{
	public class Recipe
	{
		public int Id { get; set; }
		public string Name { get; set; } = "";
		public ICollection<Tag> Tags { get; set; } = new List<Tag>();
	}
}