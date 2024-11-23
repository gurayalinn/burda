using burda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace burda.Controllers
{
    internal class RoleController : BaseController<Role>
    {
        public RoleController() : base()
        {
        }

        public Role FindRoleByName(string roleName)
        {
            return _context.Roles.FirstOrDefault(r => r.RoleName == roleName);
        }

        public List<Role> FindRolesByUser(User user)
        {
            return _context.Roles.Where(r => r.Users.Contains(user)).ToList();
        }
    }
}
