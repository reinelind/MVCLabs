
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication2.Models;


public class TypeModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
}


namespace MVC2_1.Controllers
{
    public class WApiController : ApiController
    {
        private Database2Entities db = new Database2Entities();

        [HttpGet]
        [ActionName ("GetType")]
        public ICollection<TypeModel> GetType(int id)
        {
            var type = (from tp in db.Type select tp).ToList();
            Collection<TypeModel> TM = new Collection<TypeModel>();

            foreach (WebApplication2.Models.Type t in type)
            {
                TM.Add(new TypeModel { Id = t.TypeId, Name = t.Name, Model = t.Model });
            }

            return TM;
        }

        [HttpPost]
        [ActionName("CreateType")]
        public HttpResponseMessage CreateType (WebApplication2.Models.Type type)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);

            try
            {
                db.Type.Add(type);
                db.SaveChanges();
                response.Content = new StringContent("{Id:" + type.TypeId + ",Name:" + type.Name
                    + ",Model" + type.Model + "}", System.Text.Encoding.UTF8, "appllication/json");
            }
            catch (Exception ex)
            {
                response.Content = new StringContent("{Error:" + ex.Message + "}", System.Text.Encoding.UTF8, "application/json")
            ;
            }

            return response;
        }

        [HttpPost]
        [ActionName("UpdateType")]
        public HttpResponseMessage UpdateType(WebApplication2.Models.Type type)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);
            var t = (from tp in db.Type where tp.TypeId == type.TypeId select tp).First();
            try
            {
                db.Type.Remove(t);
                db.Type.Add(type);
                db.SaveChanges();
                response.Content = new StringContent("{Id:" + type.TypeId + ",Name:" + type.Name
                    + ",Model" + type.Model + "}", System.Text.Encoding.UTF8, "appllication/json");
            }
            catch (Exception ex)
            {
                response.Content = new StringContent("{Error:" + ex.Message + "}", System.Text.Encoding.UTF8, "application/json")
            ;
            }

            return response;
        }

        [HttpPost]
        [ActionName("DeleteType")]
        public HttpResponseMessage DeleteType(WebApplication2.Models.Type type)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);
            var t = (from tp in db.Type where tp.TypeId == type.TypeId select tp).First();
            try
            {
                db.Type.Remove(t);
                db.SaveChanges();
                response.Content = new StringContent("{Id:" + type.TypeId + ",Name:" + type.Name
                    + ",Model" + type.Model + "}", System.Text.Encoding.UTF8, "appllication/json");
            }
            catch (Exception ex)
            {
                response.Content = new StringContent("{Error:" + ex.Message + "}", System.Text.Encoding.UTF8, "application/json")
            ;
            }

            return response;
        }


    }
}
