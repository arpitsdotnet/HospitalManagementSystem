using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using HMS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HMS.Repositories.Implementations;
public class GenericRepository<T> : IGenericRepository<T>, IDisposable where T : class
{
    private readonly ApplicationDbContext _context;
    internal DbSet<T> dbSet;

    public GenericRepository(ApplicationDbContext context)
    {
        _context = context;
        dbSet = _context.Set<T>();
    }

    public void Add(T item)
    {
        dbSet.Add(item);
    }

    public async Task<T> AddAsync(T item)
    {
        dbSet.Add(item);
        return item;
    }

    public void Delete(T item)
    {
        if (_context.Entry(item).State == EntityState.Detached)
        {
            dbSet.Attach(item);
        }
        dbSet.Remove(item);
    }

    public async Task<T> DeleteAsync(T item)
    {
        if (_context.Entry(item).State == EntityState.Detached)
        {
            dbSet.Attach(item);
        }
        dbSet.Remove(item);
        return item;
    }

    public IEnumerable<T> GetAll(Expression<Func<T?, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
    {
        IQueryable<T> query = dbSet;
        if (filter != null)
        {
            query = query.Where(filter);
        }
        foreach (var includeProperty in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(includeProperty);
        }
        if(orderBy != null)
        {
            return orderBy(query).ToList();
        }
        return query.ToList();
    }
    
    public T GetById(object Id)
    {
        return dbSet.Find(Id);
    }

    public async Task<T> GetByIdAsync(object Id)
    {
        return await dbSet.FindAsync(Id);
    }

    public void Update(T item)
    {
        dbSet.Attach(item);
        _context.Entry(item).State = EntityState.Modified;
    }

    public async Task<T> UpdateAsync(T item)
    {
        dbSet.Attach(item);
        _context.Entry(item).State = EntityState.Modified;
        return item;
    }

    #region DISPOSABLE CODE

    private bool _disposed = false;
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if (_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        _disposed = true;
    }

    #endregion
}
