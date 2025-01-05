using burda.Helpers;
using burda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace burda.Controllers
{
    internal class ClassRoomController : BaseController<ClassRoom>
    {
        public ClassRoomController() : base()
        {
        }

        public bool AddClassRoom(ClassRoom NewClassRoom)
        {
            try
            {
                Create(NewClassRoom);
                Logger.Information($"{NewClassRoom.ClassName} - {NewClassRoom.LessonName} sınıf oluşturuldu.");
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error($"Error creating ClassRoom: {ex.Message}");
                throw new Exception($"Error creating ClassRoom: {ex.Message}");
            }
        }


        public List<ClassRoom> GetAllClassRooms()
        {
            return _context.ClassRooms.ToList();
        }

        public List<ClassRoom> FindClassesByTeacherID(int TeacherID)
        {
            return _context.ClassRooms.Where(c => c.TeacherID == TeacherID).ToList();
        }

        public List<ClassRoom> FindClassesByClassName(String ClassName)
        {
            return _context.ClassRooms.Where(c => c.ClassName == ClassName).ToList();
        }

        public List<ClassRoom> FindClassesByLessonName(String LessonName)
        {
            return _context.ClassRooms.Where(c => c.LessonName == LessonName).ToList();
        }

        public List<ClassRoom> FindClassesByTeacher(User teacher)
        {
            return _context.ClassRooms.Where(c => c.TeacherID == teacher.ID).ToList();
        }

        public List<ClassRoom> FindClassesByStudent(User student)
        {
            return _context.ClassRooms.Where(c => c.Students.Contains(student)).ToList();
        }

        public ClassRoom FindClassByClassName(String ClassName)
        {
            return _context.ClassRooms.FirstOrDefault(c => c.ClassName == ClassName);
        }

        public ClassRoom FindClassByClassID(int ClassID)
        {
            return _context.ClassRooms.FirstOrDefault(c => c.ID == ClassID);
        }

        public List<ClassRoom> FindClassesByDate(DateTime date)
        {
            return _context.ClassRooms.Where(c => c.ClassDate == date).ToList();
        }

        public List<ClassRoom> FindClassesByIsExam(bool isExam)
        {
            return _context.ClassRooms.Where(c => c.IsExam == isExam).ToList();
        }

        public List<Attendance> GetAttendanceList(int ClassID)
        {
            return _context.Attendances.Where(a => a.ClassID == ClassID).ToList();
        }

        public List<Attendance> GetAttendanceListToday(int ClassID)
        {
            var today = DateTime.Now.Date;
            return _context.Attendances
                           .Where(a => a.ClassID == ClassID)
                           .AsEnumerable()
                           .Where(a => a.AttTime.Date == today)
                           .ToList();
        }

        internal object Search(string text)
        {
            return _context.ClassRooms.Where(c => c.ClassName.Contains(text) || c.LessonName.Contains(text)).ToList();
        }

        public bool UpdateClassRoom(ClassRoom updatedClassRoom)
        {
            try
            {
                ClassRoom existingClassRoom = _context.ClassRooms.FirstOrDefault(c => c.ID == updatedClassRoom.ID);
                if (existingClassRoom == null)
                {
                    throw new Exception("Sınıf bulunamadı.");
                }

                existingClassRoom.ClassName = updatedClassRoom.ClassName;
                existingClassRoom.LessonName = updatedClassRoom.LessonName;
                existingClassRoom.ClassDate = updatedClassRoom.ClassDate;
                existingClassRoom.StartTime = updatedClassRoom.StartTime;
                existingClassRoom.EndTime = updatedClassRoom.EndTime;
                existingClassRoom.IsExam = updatedClassRoom.IsExam;
                existingClassRoom.UpdatedDate = DateTime.Now;
                existingClassRoom.TeacherID = updatedClassRoom.TeacherID;

                Update(existingClassRoom);
                Logger.Information($"{existingClassRoom.ClassName} - {existingClassRoom.LessonName} - {existingClassRoom.Teacher.FullName} sınıf güncellendi.");
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error($"Error updating ClassRoom: {ex.Message}");
                throw new Exception($"Error updating ClassRoom: {ex.Message}");
            }
        }
    }
}