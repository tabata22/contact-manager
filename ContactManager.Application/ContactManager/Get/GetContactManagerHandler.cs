using ContactManager.Domain;
using ContactManager.Domain.Entities;
using MediatR;

namespace ContactManager.Application.ContactManager.Get;

public sealed class GetContactManagerHandler :
    IRequestHandler<GetByIdQuery, ContactManagerEntity?>,
    IRequestHandler<GetAllQuery, IReadOnlyCollection<ContactManagerEntity>>
{
    private readonly IContactManagerRepository _repository;

    public GetContactManagerHandler(IContactManagerRepository repository)
    {
        _repository = repository;
    }

    public async Task<ContactManagerEntity?> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        => await _repository.GetByIdAsync(request.Id, cancellationToken).ConfigureAwait(false);

    public async Task<IReadOnlyCollection<ContactManagerEntity>> Handle(GetAllQuery request, CancellationToken cancellationToken) 
        => await _repository.GetAllAsync(cancellationToken).ConfigureAwait(false);
}