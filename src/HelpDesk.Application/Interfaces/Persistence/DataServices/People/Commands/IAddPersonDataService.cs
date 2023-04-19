using HelpDesk.Domain.Entities;

namespace HelpDesk.Application.Interfaces.Persistence.DataServices.People.Commands;

public interface IAddPersonDataService
{
    Task<Person> ExecuteAsync(Person person, CancellationToken cancellationToken = default);
}

