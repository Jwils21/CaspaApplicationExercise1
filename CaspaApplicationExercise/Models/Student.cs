using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaspaApplicationExercise.Models {
	public class Student {
		public int Id { get; set; }
		public string Name { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
		public string Address { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public bool Active { get; set; } = true;

		public Student() { }
	}
}