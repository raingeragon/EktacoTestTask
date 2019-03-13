using EktacoTestTask.Models;
using EktacoTestTask.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Net;

namespace EktacoTestTask.Controllers
{
    public class GroupController : ApiController
    {
        private IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpGet]
        public HttpResponseMessage GetGroups()
        {
            var jsonproduct = Newtonsoft.Json.JsonConvert.SerializeObject(_groupService.GetGroupTree());
            return Request.CreateResponse(HttpStatusCode.OK, jsonproduct.ToString());

        }
    }
}
