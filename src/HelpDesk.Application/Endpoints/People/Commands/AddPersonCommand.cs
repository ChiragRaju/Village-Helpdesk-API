using HelpDesk.Application.Models;
using MediatR;

namespace HelpDesk.Application.Endpoints.People.Commands;

public class AddPersonCommand : IRequest<EndpointResult<PersonViewModel>>
{
    public int? Id { get; init; }
    public string FirstName { get; init; } = "";
    public string LastName { get; init; } = "";
}
