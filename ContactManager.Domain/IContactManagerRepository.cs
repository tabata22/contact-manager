using ContactManager.Domain.Entities;

namespace ContactManager.Domain;

public interface IContactManagerRepository
{
    Task<ContactManagerEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    
    Task<IReadOnlyCollection<ContactManagerEntity>> GetAllAsync(CancellationToken cancellationToken);
    
    Task CreateAsync(ContactManagerEntity entity, CancellationToken cancellationToken);
    
    Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken);
    
    Task<bool> CheckByEmailAsync(string email, CancellationToken cancellationToken);
    
    Task UpdateAsync(ContactManagerEntity entity, CancellationToken cancellationToken);
}