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
    public async Task<Owner> GetOwnerData(int ownerId)
    {
        return await _dbService.GetOwnerData(ownerId);
    }

    [HttpPost]
    public async Task PostOwnerData()
    {
        
    }
}