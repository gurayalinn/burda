using burda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace burda.Controllers
{
    internal class UserController : BaseController<User>
    {
        public UserController() : base()
        {

        }

        public List<User> GetAllStudents()
        {
            return _context.Users.Where(u => u.Role.RoleName == "STUDENT").ToList();
        }


        public User Login(string email, string password)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }

        public User FindUserByStudentID(string StudentID)
        {
            return _context.Users.FirstOrDefault(u => u.StudentID == StudentID);
        }

        public User FindUserByCardNumber(string cardNumber)
        {
            return _context.Users.FirstOrDefault(u => u.RFIDCard.RFIDNumber == cardNumber);
        }

        public User FindUserByUserEmail(string userEmail)
        {
            return _context.Users.FirstOrDefault(u => u.Email == userEmail);
        }

        public User FindUserByFullName(string fullName)
        {
            return _context.Users.FirstOrDefault(u => u.FullName == fullName);
        }

        public List<User> FindUsersByRole(string roleName)
        {
            return _context.Users.Where(u => u.Role.RoleName == roleName).ToList();
        }

        public List<User> FindUsersByRole(Role role)
        {
            return _context.Users.Where(u => u.Role == role).ToList();
        }



    }
}
