using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Repositories.Interfaces;
public interface IGenericRepository<T> : IDisposable
{
    IEnumerable<T> GetAll(
        Expression<Func<T?, bool>> filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        string includeProperties = "");

    T GetById(object Id);
    Task<T> GetByIdAsync(object Id);

    void Add(T item);
    Task<T> AddAsync(T item);

    void Update(T item);
    Task<T> UpdateAsync(T item);

    void Delete(T item);
    Task<T> DeleteAsync(T item);
}
