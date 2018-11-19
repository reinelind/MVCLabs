using MVC2_1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


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

        public ICollection<TypeModel> GetType(int id)
        {
            var type = (from tp in db.Type select tp).ToList();
            Collection<TypeModel> TM = new Collection<TypeModel>();

            foreach (Models.Type t in type)
            {
                TM.Add(new TypeModel { Id = t.TypeId, Name = t.Name, Model = t.Model });
            }

            return TM;
        }
    }
}
