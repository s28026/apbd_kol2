namespace Kol2.DTOs;

public class GetOwnerDTO
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string PhoneNumer { get; set; } = string.Empty;

    public ICollection<GetOwnerObjectsDTO> OwnerObjects { get; set; } = null!;
}

public class GetOwnerObjectsDTO
{
    public int Id { get; set; }
    public decimal Width { get; set; }
    public decimal Height { get; set; }
    public string Type { get; set; }
    public string Warehouse { get; set; }
}