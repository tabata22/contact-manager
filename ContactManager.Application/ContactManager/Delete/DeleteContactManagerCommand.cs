using MediatR;

namespace ContactManager.Application.ContactManager.Delete;

public record DeleteContactManagerCommand(Guid Id) : IRequest;