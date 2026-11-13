using FacturacionInternet.Domain.Repository;
using FacturacionInternet.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace FacturacionInternet.Infrastructure.Core;

public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected readonly FacturacionContext _context;
    protected readonly DbSet<T> _dbSet;

    protected BaseRepository(FacturacionContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<T> AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }
}