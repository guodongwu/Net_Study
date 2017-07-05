using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using MyMvcSummary.Models;

namespace MyMvcSummary.Controllers
{
    public class ProjectController : ApiController
    {

        public Connection GetUserModels()
        {
            Connection user = new Connection
            {
                ConnectionID = "aaaaaa",
                UserAgent = "aaa",
                Connected = true
            };
            return user;
        }

    }
}
