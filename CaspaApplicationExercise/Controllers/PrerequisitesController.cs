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
    public class PrerequisitesController : ApiController
    {
		private CaspaExerciseDbContext db = new CaspaExerciseDbContext();

		//GET-ALL
		//indicates that a get method will be used to get this info vs. post which updates
		[HttpGet]
		[ActionName("List")] //this is the name the client will use to call this method
		public JsonResponse List() {
			return new JsonResponse {
				Data = db.Prerequisites.ToList()
			};
		}

		//GET-ONE
		[HttpGet]
		[ActionName("Get")]
		public JsonResponse Prerequisites(int? id) {
			if(id == null) {
				return new JsonResponse {
					Result = "Failed",
					Message = "Id does not exist"
				};
			}
			return new JsonResponse {
				Data = db.Prerequisites.Find(id)
			};
		}

		//POST
		[HttpPost]
		[ActionName("Create")]
		public JsonResponse Create(Prerequisite prerequisite) {
			if(prerequisite == null) {
				return new JsonResponse {
					Result = "Failed",
					Message = "Create requires an instance of PreRequisites"
				};
			}
			if(!ModelState.IsValid) {
				return new JsonResponse {
					Result = "Failed",
					Message = "Model state is invalid. See data.",
					Error = ModelState
				};
			}

			db.Prerequisites.Add(prerequisite);
			db.SaveChanges();
			return new JsonResponse {
				Message = "Create successful.",
				Data = prerequisite
			};
		}

		//CHANGE
		[HttpPost]
		[ActionName("Change")]
		public JsonResponse Change(Prerequisite prerequisite) {
			if(prerequisite == null) {
				return new JsonResponse {
					Result = "Failed",
					Message = "Create requires an instance of PreRequisite"
				};
			}
			if(!ModelState.IsValid) {
				return new JsonResponse {
					Result = "Failed",
					Message = "Model state is invalid. See data.",
					Error = ModelState
				};
			}
			db.Entry(prerequisite).State = System.Data.Entity.EntityState.Modified;
			db.SaveChanges();
			return new JsonResponse {
				Message = "Change successful.",
				Data = prerequisite
			};
		}

		//DELETE
		[HttpPost]
		[ActionName("Remove")]
		public JsonResponse Remove(Prerequisite prerequisite) {
			if(prerequisite == null) {
				return new JsonResponse {
					Result = "Failed",
					Message = "Create requires an instance of Prerequisite"
				};
			}
			if(!ModelState.IsValid) {
				return new JsonResponse {
					Result = "Failed",
					Message = "Model state is invalid. See data.",
					Error = ModelState
				};
			}
			db.Entry(prerequisite).State = System.Data.Entity.EntityState.Deleted;
			db.SaveChanges();
			return new JsonResponse {
				Message = "Remove successful.",
				Data = prerequisite
			};
		}

		//REMOVE/ID
		[HttpPost]
		[ActionName("RemoveId")]
		public JsonResponse Remove(int? id) {
			if(id == null)
				return new JsonResponse {
					Result = "Failed",
					Message = "RemoveId requires a Prerequisite.Id"
				};
			var prerequisite = db.Prerequisites.Find(id);
			if(prerequisite == null)
				return new JsonResponse {
					Result = "Failed",
					Message = $"No Prerequisites have Id of {id}"
				};
			db.Prerequisites.Remove(prerequisite);
			db.SaveChanges();
			return new JsonResponse {
				Message = "Remove successful.",
				Data = prerequisite
			};
		}

	}
}
