using burda.Helpers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace burda.Controllers
{
    public class BaseController<T> where T : class
    {
        protected AppDbContext _context;



        public BaseController()
        {
            _context = new AppDbContext();
        }

        public T Create(T entity)
        {
            try
            {
                _context.Set<T>().Add(entity);
                _context.SaveChanges();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error creating {typeof(T).Name}: {ex.Message}");
            }
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public void Update(T entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating {typeof(T).Name}: {ex.Message}");
            }
        }

        public void DeleteById(int id)
        {
            try
            {
                var entity = GetById(id);
                if (entity != null)
                {
                    _context.Set<T>().Remove(entity);
                    _context.SaveChanges();
                }
                else
                {
                    throw new Exception($"{typeof(T).Name} with ID {id} not found.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting {typeof(T).Name}: {ex.Message}");
            }
        }

        public void Delete(T entity)
        {
            try
            {
                _context.Set<T>().Remove(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting {typeof(T).Name}: {ex.Message}");
            }
        }
    }
}
