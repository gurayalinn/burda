using burda.Helpers;
using burda.Models;
using burda.Views;
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

        public bool AddUser(User newUser)
        {
            try
            {
                if (_context.Users.Any(u => u.Email == newUser.Email) || _context.Users.Any(u => u.StudentID == newUser.StudentID))
                {
                    return false;
                }

                Create(newUser);
                Logger.Information($"{newUser.RoleName} - {newUser.FullName} yeni kullanıcı oluşturuldu.");
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error($"Error creating user: {ex.Message}");
                throw new Exception($"Error creating user: {ex.Message}");
            }
        }


        public List<User> GetAllStudents()
        {
            return _context.Users.Where(u => u.Role.RoleName == "STUDENT").ToList();
        }

        public List<User> GetAllTeachers()
        {
            return _context.Users.Where(u => u.Role.RoleName == "TEACHER").ToList();
        }


        public User Login(string email, string password)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password && u.Role.RoleName != "STUDENT");
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


        internal object Search(string text)
        {
                return _context.Users.Where(u => u.Email.Contains(text) || u.StudentID.Contains(text) || u.Role.RoleName.Contains(text) || u.RFIDCard.RFIDNumber.Contains(text) || u.FirstName.Contains(text) || u.LastName.Contains(text)).ToList();
        }

        public bool UpdateUser(User updatedUser)
        {
            try
            {
                var existingUser = _context.Users.FirstOrDefault(u => u.ID == updatedUser.ID);
                if (existingUser == null)
                {
                    throw new Exception("Kullanıcı bulunamadı.");
                }


                if (existingUser.RFIDCard != null) {
                existingUser.StudentID = updatedUser.StudentID;
                existingUser.FirstName = updatedUser.FirstName;
                existingUser.LastName = updatedUser.LastName;
                existingUser.Email = updatedUser.Email;
                existingUser.Password = updatedUser.Password;
                existingUser.ProfileImage = updatedUser.ProfileImage;
                existingUser.ProgramName = updatedUser.ProgramName;
                existingUser.UpdatedDate = updatedUser.UpdatedDate;
                existingUser.RoleID = updatedUser.RoleID;
                existingUser.RFIDCardID = updatedUser.RFIDCardID;
                }


                    if (existingUser != null) {
                {
                    if (_context.Users.Any(u => u.RFIDCardID == updatedUser.RFIDCardID && u.ID != updatedUser.ID))
                    {
                        return false;
                    }
                }
                }


                Update(existingUser);

                Logger.Information($"{existingUser.RoleName} - {existingUser.FullName} kullanıcı bilgileri güncellendi.");
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error($"Error updating user: {ex.Message}");
                throw new Exception($"Error updating user: {ex.Message}");
            }
        }
    }
}
