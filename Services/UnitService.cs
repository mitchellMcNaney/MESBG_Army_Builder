using Mesbg.Api.Data;
using Mesbg.Api.Models;
using Microsoft.EntityFrameworkCore;


 namespace Mesbg.Api.Services;

 public class UnitService
{
    private readonly MesbgDbContext _context;
    public UnitService(MesbgDbContext context)
    {
        _context = context;
    }

    public async Task<List<Unit>> GetAllUnitsAsync()
    {
        var units = await _context.Unit.ToListAsync();
        return units;
    }

}