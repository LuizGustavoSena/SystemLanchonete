using Data;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace API.Controllers
{
    public class PizzaController : ApiController
    {
        // GET api/pizza
        public IEnumerable<Pizza> Get()
        {
            return new PizzaDB().Select();
        }

        // POST api/pizza
        public bool Post([FromBody] Pizza pizza)
        {
            return new PizzaDB().Insert(pizza);
        }
    }
}