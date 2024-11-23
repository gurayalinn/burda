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
    }
}