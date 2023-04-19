using HelpDesk.Domain.Entities;

namespace HelpDesk.Application.Interfaces.Persistence.DataServices.People.Queries;

public interface IGetPeopleDataService
{
    Task<IEnumerable<Person>> ExecuteAsync(bool includeInactive, CancellationToken cancellationToken = default);
}
