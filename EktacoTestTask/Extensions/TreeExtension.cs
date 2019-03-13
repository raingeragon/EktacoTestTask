using EktacoTestTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EktacoTestTask.Extensions
{
    public static class TreeExtension
    {
        public static IEnumerable<Group> ToTree(this IEnumerable<Group> groups)
        {
            if (groups == null)
                return new List<Group>();
            var roots = groups.Where(g => g.ParentId == 0);
            if (roots == null)
                return new List<Group>();
            foreach (var root in roots)
            {
                Search(root, groups);
            }

            return groups;
        }

        private static void Search(Group node, IEnumerable<Group> groups)
        {
            var children = groups.Where(x => x.ParentId.Equals(node.Id)).ToList();
            if (children != null)
            {
                foreach (var item in children)
                {
                    if (node.Children == null) 
                        node.Children = new List<Group>();
                    node.Children.Add(item);
                }

                foreach (var item in children)
                    groups.ToList().Remove(item);

                foreach (var item in children)
                    Search(item, groups);
            }
        }
    }
}