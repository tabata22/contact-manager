using ContactManager.Domain;
using MediatR;

namespace ContactManager.Application.ContactManager.Delete;

public sealed class DeleteContactManagerHandler : IRequestHandler<DeleteContactManagerCommand>
{
    private readonly IContactManagerRepository _repository;

    public DeleteContactManagerHandler(IContactManagerRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(DeleteContactManagerCommand request, CancellationToken cancellationToken) 
        => await _repository.DeleteByIdAsync(request.Id, cancellationToken).ConfigureAwait(false);
}