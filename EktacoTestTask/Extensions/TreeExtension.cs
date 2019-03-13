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
            var childs = groups.Where(x => x.ParentId.Equals(node.Id)).ToList();

            foreach (var item in childs)
            {
                node.Children.Add(item);
            }

            foreach (var item in childs)
                groups.ToList().Remove(item);

            foreach (var item in childs)
                Search(item, groups);
        }
    }
}