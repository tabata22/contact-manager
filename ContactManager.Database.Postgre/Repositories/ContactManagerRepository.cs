using ContactManager.Database.Postgre.DalEntities;
using ContactManager.Database.Postgre.Extensions;
using ContactManager.Domain;
using ContactManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Database.Postgre.Repositories;

public sealed class ContactManagerRepository : IContactManagerRepository
{
    private readonly ContactManagerDbContext _dbContext;

    public ContactManagerRepository(ContactManagerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ContactManagerEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var dalEntity = await _dbContext.ContactManagers
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken)
            .ConfigureAwait(false);

        return dalEntity?.ToDomain();
    }

    public async Task<IReadOnlyCollection<ContactManagerEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        var dalEntities = await _dbContext.ContactManagers.AsNoTracking()
            .ToListAsync(cancellationToken)
            .ConfigureAwait(false);

        return dalEntities.Select(x => x.ToDomain()).ToList();
    }

    public async Task CreateAsync(ContactManagerEntity entity, CancellationToken cancellationToken)
    {
        var dalEntity = new ContactManagerDal
        {
            Id = entity.Id,
            Salution = entity.Salution,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            BirthDate = entity.BirthDate,
            DisplayName = entity.DisplayName,
            CreationTimestamp = entity.CreationTimestamp,
            Email = entity.Email,
            PhoneNumber = entity.PhoneNumber
        };

        await _dbContext.ContactManagers.AddAsync(dalEntity, cancellationToken).ConfigureAwait(false);
        await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    }

    public async Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.ContactManagers.FirstOrDefaultAsync(x => x.Id == id, cancellationToken).ConfigureAwait(false);
        if (entity is null)
            return;

        _dbContext.ContactManagers.Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    }

    public async Task<bool> CheckByEmailAsync(string email, CancellationToken cancellationToken)
        => await _dbContext.ContactManagers.AnyAsync(x => x.Email == email, cancellationToken)
            .ConfigureAwait(false);

    public async Task UpdateAsync(ContactManagerEntity entity, CancellationToken cancellationToken)
    {
        var existing = await _dbContext.ContactManagers
            .FirstOrDefaultAsync(x => x.Id == entity.Id, cancellationToken)
            .ConfigureAwait(false);
        if (existing is null)
            return;

        existing.FirstName = entity.FirstName;
        existing.LastName = entity.LastName;
        existing.BirthDate = entity.BirthDate;
        existing.DisplayName = entity.DisplayName;
        existing.PhoneNumber = entity.PhoneNumber;
        existing.LastChangeTimestamp = entity.LastChangeTimestamp;

        _dbContext.ContactManagers.Update(existing);
        await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    }
}