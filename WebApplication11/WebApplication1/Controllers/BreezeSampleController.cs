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

namespace WebApplication1.Controllers
{
    [BreezeController]
    public class BreezeSampleController : ApiController
    {

        public EFContextProvider<NorthwindEntities> _contextProvider =new EFContextProvider<NorthwindEntities>();

        /// <summary>
        /// http://localhost:2864/breeze/BreezeSample/metadata
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// http://localhost:2864/breeze/BreezeSample/Region
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IQueryable<Region> Region()
        {
            return _contextProvider.Context.Regions;
        }

        [HttpGet]
        public IQueryable<Customer> Customers()
        {
            return _contextProvider.Context.Customers;
        }

        [HttpGet]
        public IQueryable<Order> Orders()
        {
            return _contextProvider.Context.Orders;
        }
    }
}
