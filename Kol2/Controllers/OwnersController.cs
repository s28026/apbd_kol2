using Kol2.Models;
using Kol2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kol2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OwnersController : ControllerBase
{
    private readonly IDbService _dbService;
    public OwnersController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet("/{ownerId}")]
    public async Task<IActionResult> GetOwnerData(int ownerId)
    {
        var owner =  await _dbService.GetOwnerData(ownerId);
        if (owner is null)
            return NotFound($"Owner with ID - {ownerId} not found");

        return Ok(new
        {
            FirstName = owner.FirstName,
            LastName = owner.LastName,
            PhoneNumber = owner.PhoneNumber,
            OwnerObjects    = owner.ObjectOwners.Select(o=>new
            {
                Id = o.ObjectId,
                Width = o.Object.Width,
                Height = o.Object.Height,
                Type = o.Object.ObjectType.Name,
                Warehouse = o.Object.Warehouse.Name,
            })
        });
    }

    [HttpPost]
    public async Task PostOwnerData()
    {
        
    }
}