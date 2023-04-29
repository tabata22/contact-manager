using ContactManager.Database.Postgre.DalEntities;
using ContactManager.Domain.Entities;

namespace ContactManager.Database.Postgre.Extensions;

public static class ContactManagerExtension
{
    public static ContactManagerEntity ToDomain(this ContactManagerDal contactManager)
    {
        var displayName = contactManager.DisplayName;
        if (string.IsNullOrWhiteSpace(contactManager.DisplayName))
            displayName = $"{contactManager.Salution} {contactManager.FirstName} {contactManager.LastName}";

        return new ContactManagerEntity(
            contactManager.Id,
            contactManager.Salution,
            contactManager.FirstName,
            contactManager.LastName,
            displayName,
            contactManager.BirthDate,
            contactManager.Email,
            contactManager.PhoneNumber,
            contactManager.CreationTimestamp,
            contactManager.LastChangeTimestamp
            );
    }
}