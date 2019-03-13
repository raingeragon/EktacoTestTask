using EktacoTestTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EktacoTestTask.Services
{
    public interface IGroupService
    {
        IEnumerable<Group> GetGroupTree();
    }
}
