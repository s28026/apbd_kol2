using System.ComponentModel.DataAnnotations;

namespace Kol2.DTOs;

public class AddNewOwnerDTO
{
    [MaxLength(50)]
    public string FirstName { get; set; }
    [MaxLength(50)]
    public string LastName { get; set; }
    [MaxLength(9)]
    public string PhoneNumber { get; set; }
    
    public ICollection<int> OwnerObjects { get; set; } = new HashSet<int>();
}