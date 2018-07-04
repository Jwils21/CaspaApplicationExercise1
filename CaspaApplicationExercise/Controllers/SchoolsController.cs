using CaspaApplicationExercise.Models;
using CaspaApplicationExercise.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CaspaApplicationExercise.Controllers
{
    public class SchoolsController : ApiController
    {
		private CaspaExerciseDbContext db = new CaspaExerciseDbContext();

		//GET-ALL
		//indicates that a get method will be used to get this info vs. post which updates
		[HttpGet]
		[ActionName("List")] //this is the name the client will use to call this method
		public JsonResponse List() {
			return new JsonResponse {
				Data = db.Schools.ToList()
			};
		}

		//GET-ONE
		[HttpGet]
		[ActionName("Get")]
		public JsonResponse Schools(int? id) {
			if(id == null) {
				return new JsonResponse {
					Result = "Failed",
					Message = "Id does not exist"
				};
			}
			return new JsonResponse {
				Data = db.Schools.Find(id)
			};
		}

		//POST
		[HttpPost]
		[ActionName("Create")]
		public JsonResponse Create(School school) {
			if(school == null) {
				return new JsonResponse {
					Result = "Failed",
					Message = "Create requires an instance of School"
				};
			}
			if(!ModelState.IsValid) {
				return new JsonResponse {
					Result = "Failed",
					Message = "Model state is invalid. See data.",
					Error = ModelState
				};
			}

			db.Schools.Add(school);
			db.SaveChanges();
			return new JsonResponse {
				Message = "Create successful.",
				Data = school
			};
		}

		//CHANGE
		[HttpPost]
		[ActionName("Change")]
		public JsonResponse Change(School school) {
			if(school == null) {
				return new JsonResponse {
					Result = "Failed",
					Message = "Create requires an instance of School"
				};
			}
			if(!ModelState.IsValid) {
				return new JsonResponse {
					Result = "Failed",
					Message = "Model state is invalid. See data.",
					Error = ModelState
				};
			}
			db.Entry(school).State = System.Data.Entity.EntityState.Modified;
			db.SaveChanges();
			return new JsonResponse {
				Message = "Change successful.",
				Data = school
			};
		}

		//DELETE
		[HttpPost]
		[ActionName("Remove")]
		public JsonResponse Remove(School school) {
			if(school == null) {
				return new JsonResponse {
					Result = "Failed",
					Message = "Create requires an instance of School"
				};
			}
			if(!ModelState.IsValid) {
				return new JsonResponse {
					Result = "Failed",
					Message = "Model state is invalid. See data.",
					Error = ModelState
				};
			}
			db.Entry(school).State = System.Data.Entity.EntityState.Deleted;
			db.SaveChanges();
			return new JsonResponse {
				Message = "Remove successful.",
				Data = school
			};
		}

		//REMOVE/ID
		[HttpPost]
		[ActionName("RemoveId")]
		public JsonResponse Remove(int? id) {
			if(id == null)
				return new JsonResponse {
					Result = "Failed",
					Message = "RemoveId requires a School.Id"
				};
			var school = db.Schools.Find(id);
			if(school == null)
				return new JsonResponse {
					Result = "Failed",
					Message = $"No Schools have Id of {id}"
				};
			db.Schools.Remove(school);
			db.SaveChanges();
			return new JsonResponse {
				Message = "Remove successful.",
				Data = school
			};
		}


	}
}
