using EktacoTestTask.Entities;
using EktacoTestTask.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net.Http;

namespace EktacoTestTask.Controllers
{
    public class GroupController : ApiController
    {
        private GroupService _groupService;

        public GroupController(GroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpGet]
        public List<Group> GetGroups()
        {
            return new List<Group>();
        }
    }
}
