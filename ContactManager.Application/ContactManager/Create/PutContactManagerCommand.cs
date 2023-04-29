using System.ComponentModel.DataAnnotations;
using MediatR;

namespace ContactManager.Application.ContactManager.Create;

public sealed record PutContactManagerCommand : IRequest
{
    public Guid Id { get; init; }
    
    [Required, MinLength(3)]
    public string Salution { get; init; } = null!;
    
    [Required, MinLength(3)]
    public string FirstName { get; init; } = null!;
    
    [Required, MinLength(3)]
    public string LastName { get; init; } = null!;
    
    public string? DisplayName { get; init; }
    
    public DateTime? BirthDate { get; init; }

    [Required] public string Email { get; init; } = null!;
    
    public string? PhoneNumber { get; init; }
}