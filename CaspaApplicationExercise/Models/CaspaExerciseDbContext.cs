using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CaspaApplicationExercise.Models {
	public class CaspaExerciseDbContext: DbContext {
		public DbSet<Student> Students { get; set; }
		public DbSet<School> Schools { get; set; }
		public DbSet<Prerequisite> Prerequisites { get; set; }

		public CaspaExerciseDbContext(): base() { }
	}
}