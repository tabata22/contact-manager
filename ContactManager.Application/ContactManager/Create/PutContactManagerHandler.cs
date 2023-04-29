using ContactManager.Domain;
using ContactManager.Domain.Entities;
using MediatR;

namespace ContactManager.Application.ContactManager.Create;

public sealed class PutContactManagerHandler : IRequestHandler<PutContactManagerCommand>
{
    private readonly IContactManagerRepository _repository;
    
    public PutContactManagerHandler(IContactManagerRepository repository)
    {
        _repository = repository;
    }
    
    public async Task Handle(PutContactManagerCommand request, CancellationToken cancellationToken)
    {
        var existingEntity = await _repository.GetByIdAsync(request.Id, cancellationToken).ConfigureAwait(false);
        if (existingEntity is not null)
        {
            existingEntity.Update(
                request.FirstName,
                request.LastName,
                request.DisplayName,
                request.BirthDate,
                request.Email,
                request.PhoneNumber
                );
            
            await _repository.UpdateAsync(existingEntity, cancellationToken).ConfigureAwait(false);
            
            return;
        }

        var isEmailExists = await _repository.CheckByEmailAsync(request.Email, cancellationToken).ConfigureAwait(false);
        if (isEmailExists)
            return;

        var entity = new ContactManagerEntity(
            id: Guid.NewGuid(),
            request.Salution,
            request.FirstName,
            request.LastName,
            request.DisplayName,
            request.BirthDate,
            request.Email,
            request.PhoneNumber,
            DateTime.UtcNow,
            lastChangeTimestamp: default);
        
        await _repository.CreateAsync(entity, cancellationToken).ConfigureAwait(false);
    }
}