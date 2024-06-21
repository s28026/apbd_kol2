using Kol2.Data;
using Kol2.DTOs;
using Kol2.Models;
using Microsoft.EntityFrameworkCore;

namespace Kol2.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;
    public DbService(DatabaseContext context)
    {
        _context = context;
    }
    
    public async Task<Owner> GetOwnerData(int ownerId)
    {
        return await _context.Owners
            .Include(o => o.ObjectOwners)
            .ThenInclude(oo => oo.Object)
            .Where(o => o.Id == ownerId)
            .FirstAsync();
    }
}