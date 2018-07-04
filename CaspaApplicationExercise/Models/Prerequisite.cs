using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaspaApplicationExercise.Models {
	public class Prerequisite {
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public bool Active { get; set; }
		public int SchoolId { get; set; }
		public virtual School School { get; set; }


		public Prerequisite() { }
	}
}