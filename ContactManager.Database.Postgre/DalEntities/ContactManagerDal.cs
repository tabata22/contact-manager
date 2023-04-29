using System.ComponentModel.DataAnnotations.Schema;

namespace ContactManager.Database.Postgre.DalEntities;

public sealed class ContactManagerDal
{
    public Guid Id { get; set; }
    
    public string Salution { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string? DisplayName { get; set; }
    
    public DateTime? BirthDate { get; set; }
    
    public DateTime CreationTimestamp { get; set; }
    
    public DateTime? LastChangeTimestamp { get; set; }

    public string Email { get; set; }
    
    public string? PhoneNumber { get; set; }
}