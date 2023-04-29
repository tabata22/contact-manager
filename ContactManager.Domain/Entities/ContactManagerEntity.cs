namespace ContactManager.Domain.Entities;

public sealed class ContactManagerEntity : Entity
{
    public ContactManagerEntity(
        Guid id,
        string salution, 
        string firstName, 
        string lastName, 
        string? displayName, 
        DateTime? birthDate, 
        string email, 
        string? phoneNumber,
        DateTime creationTimestamp,
        DateTime? lastChangeTimestamp)
    {
        Id = id;
        Salution = salution;
        FirstName = firstName;
        LastName = lastName;
        DisplayName = displayName;
        BirthDate = birthDate;
        Email = email;
        PhoneNumber = phoneNumber;
        CreationTimestamp = creationTimestamp;
        LastChangeTimestamp = lastChangeTimestamp;
    }

    public string Salution { get; }
    
    public string FirstName { get; private set; }
    
    public string LastName { get; private set; }
    
    public string? DisplayName { get; private set; }
    
    public DateTime? BirthDate { get; private set; }
    
    public DateTime CreationTimestamp { get; }
    
    public DateTime? LastChangeTimestamp { get; private set; }

    public string Email { get; private set; }
    
    public string? PhoneNumber { get; private set; }
    
    public bool NotifyHasBirthdaySoon => HasBirthdaySoon();

    public void Update(
        string firstName, 
        string lastName, 
        string? displayName, 
        DateTime? birthDate, 
        string email, 
        string? phoneNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        DisplayName = displayName;
        BirthDate = birthDate;
        Email = email;
        PhoneNumber = phoneNumber;
        LastChangeTimestamp = DateTime.UtcNow;
    }

    private bool HasBirthdaySoon()
    {
        if (BirthDate is null)
            return false;

        var birthDate = new DateTime(DateTime.Now.Year, BirthDate.Value.Month, BirthDate.Value.Day);
        
        var futureDate = DateTime.Now.AddDays(14).Date;

        return birthDate.Date <= futureDate;
    }
}