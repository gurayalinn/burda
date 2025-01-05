using burda.Helpers;
using burda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace burda.Controllers
{
    internal class AttendanceController : BaseController<Attendance>
    {
        public AttendanceController() : base()
        {
        }

        public bool AddAttendance(Attendance newAttendance)
        {
            try
            {
                User user = new UserController().GetById(newAttendance.UserID);
                ClassRoom classRoom = new ClassRoomController().GetById(newAttendance.ClassID);
                Create(newAttendance);
                Logger.Information($"{user.FullName} - {classRoom.ClassName} - {classRoom.LessonName} yeni yoklama oluşturuldu.");
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error($"Error creating Attendance: {ex.Message}");
                throw new Exception($"Error creating Attendance: {ex.Message}");
            }
        }

        public Attendance FindAttendanceByUserID(int userID)
        {
            return _context.Attendances.FirstOrDefault(a => a.UserID == userID);
        }

        public Attendance FindAttendanceByClassID(int classID)
        {
            return _context.Attendances.FirstOrDefault(a => a.ClassID == classID);
        }

        public Attendance FindAttendanceByAttType(string attType)
        {
            return _context.Attendances.FirstOrDefault(a => a.AttType == attType);
        }

        public Attendance FindAttendanceByAttTime(DateTime attTime)
        {
            return _context.Attendances.FirstOrDefault(a => a.AttTime == attTime);
        }

        public List<Attendance> FindAttendancesByUserID(int userID)
        {
            return _context.Attendances.Where(a => a.UserID == userID).ToList();
        }

        public List<Attendance> FindAttendancesByClassID(int classID)
        {
            return _context.Attendances.Where(a => a.ClassID == classID).ToList();
        }

        public List<Attendance> FindAttendancesByAttType(string attType)
        {
            return _context.Attendances.Where(a => a.AttType == attType).ToList();
        }

        public List<Attendance> FindAttendancesByAttTime(DateTime attTime)
        {
            return _context.Attendances.Where(a => a.AttTime == attTime).ToList();
        }

        public List<Attendance> FindAttendancesByAttTime(DateTime attTime, DateTime attTime2)
        {
            return _context.Attendances.Where(a => a.AttTime >= attTime && a.AttTime <= attTime2).ToList();
        }

        public List<Attendance> FindAttendancesByAttTime(DateTime attTime, DateTime attTime2, int classID)
        {
            return _context.Attendances.Where(a => a.AttTime >= attTime && a.AttTime <= attTime2 && a.ClassID == classID).ToList();
        }

        public List<Attendance> FindAttendancesByAttTime(DateTime attTime, DateTime attTime2, int classID, int userID)
        {
            return _context.Attendances.Where(a => a.AttTime >= attTime && a.AttTime <= attTime2 && a.ClassID == classID && a.UserID == userID).ToList();
        }

        internal object Search(string text)
        {
            return _context.Attendances.Where(a => a.AttType.Contains(text)).ToList();
        }
    }


}
