using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.Repositories.Interfaces;

namespace HMS.Repositories.Implementations;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }
    public IGenericRepository<T> GenericRepository<T>() where T : class
    {
        IGenericRepository<T> repository = new GenericRepository<T>(_context);
        return repository;
    }

    public void Save()
    {
        _context.SaveChanges();
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
