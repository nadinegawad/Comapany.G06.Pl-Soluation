using Company.G02.BLL.Interfaces;
using Company.G02.DAL.Data.Context;
using Company.G02.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.G02.BLL.Repositiories
{
    public class GenericRepository<T> : IGenericRepository<T> where T :BaseEntity
    {
        public readonly AppDbContext _context;
        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            if (typeof(T) == typeof(Employee))
            {
                return  (IEnumerable<T>)_context.Employees.Include(E => E.Departments).ToListAsync();
            }
            return await _context.Set<T>().ToListAsync();
        }
        public async Task<T> GetAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id); 
        }
        public async Task Add(T entity)
        {
            await _context.AddAsync(entity);
            
        }
        public int Update(T entity)
        {
            _context.Update(entity);
            return _context.SaveChanges();
        }
        public int Delete(T entity)
        {
            _context.Remove(entity);
            return _context.SaveChanges();
        }

       
    }
}
