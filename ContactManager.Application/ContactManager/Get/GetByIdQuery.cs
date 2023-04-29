using ContactManager.Domain.Entities;
using MediatR;

namespace ContactManager.Application.ContactManager.Get;

public sealed record GetByIdQuery(Guid Id) : IRequest<ContactManagerEntity?>;