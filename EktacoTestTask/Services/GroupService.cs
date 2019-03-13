using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EktacoTestTask.Models;
using EktacoTestTask.Repository;
using EktacoTestTask.Extensions;

namespace EktacoTestTask.Services
{
    public class GroupService //: IGroupService
    {
        private IRepository<Entities.Group> db;

        public GroupService()
        {
            db = new Repository<Entities.Group>();
        }

        public IEnumerable<Group> GetGroupTree()
        {
            var groups = db.All() as List<Group>;
            return groups.ToTree().ToList();
        }

    }
}