using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using Dapper;
using Newtonsoft.Json;

namespace DataLoadReadReview.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/ListTables")]
    public class ListTablesController : Controller
    {
        // GET: api/ListTables
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/listTables
        [HttpGet("{db_name}")]
        public IEnumerable<string> Get(string db_name)
        {

            List<string> myCollection = new List<string>();

            using (var connection = new NpgsqlConnection("Host=127.0.0.1;port=5701;Username=arun;Password=V0zxKQd6M0Qp;Database=" + db_name + ""))
            {
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM pg_catalog.pg_tables", connection);
                NpgsqlDataReader dr = command.ExecuteReader();


                while (dr.Read())                 
                    myCollection.Add(dr[1].ToString());

            }

            var json = JsonConvert.SerializeObject(myCollection);
            yield return json;
        }

        // POST: api/ListTables
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/ListTables/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
