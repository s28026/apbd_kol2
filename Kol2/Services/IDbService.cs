using Kol2.DTOs;
using Kol2.Models;

namespace Kol2.Services;

public interface IDbService
{
    Task<Owner?> GetOwnerData(int ownerId);
}