using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EktacoTestTask.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }
        public List<Group> Children { get; set; }
    }
}