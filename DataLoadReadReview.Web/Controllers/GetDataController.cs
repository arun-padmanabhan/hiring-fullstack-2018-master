using System;  
using System.Collections.Generic;  
using System.Linq;  
using Microsoft.AspNetCore.Mvc;  

namespace DataLoadReadReview.Web.Controllers  
{  
    public class GetDataController : Controller  
    {  
        DataAccessLayer objdata = new DataAccessLayer();  
        [HttpGet]  

        [Route("api/Getdata")]  
        public IEnumerable<string> Index()  
        {  
            return objdata.GetAllTables();  
        }  
    }
}