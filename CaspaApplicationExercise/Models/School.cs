using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaspaApplicationExercise.Models {
	public class School {
		public int Id { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public bool Active { get; set; } = true;


		public School() { }
	}
}