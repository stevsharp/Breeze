using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Breeze.ContextProvider;
using Breeze.ContextProvider.EF6;
using Breeze.WebApi2;
using Newtonsoft.Json.Linq;
using WebApplication11.Ef;

namespace WebApplication11.Controllers
{
    [BreezeController]
    public class ValuesController : ApiController
    {
        readonly EFContextProvider<NorthwindEntities> _contextProvider = new EFContextProvider<NorthwindEntities>();

        [HttpGet]
        public string Metadata()
        {
            return _contextProvider.Metadata();
        }

        [HttpPost]
        public SaveResult SaveChanges(JObject saveBundle)
        {
            return _contextProvider.SaveChanges(saveBundle);
        }

        [HttpGet]
        public IQueryable<Region> Todos()
        {
            return _contextProvider.Context.Regions;
        }
    }
}
