using System.Net;
using Microsoft.AspNetCore.Mvc;
using HelpDesk.Application.Models;
using HelpDesk.Application.Models.Enumerations;

namespace HelpDesk.Api.Extensions;

public static class EndpointResultExtensions
{
    public static ActionResult ToActionResult(this EndpointResult endpointResult)
    {
        return endpointResult.Status switch
        {
            EndpointResultStatus.Success => new OkResult(),
            EndpointResultStatus.NotFound => new NotFoundResult(),
            EndpointResultStatus.Invalid when endpointResult.Messages.Count() > 0 =>
                new UnprocessableEntityObjectResult(endpointResult.Messages),
            EndpointResultStatus.Invalid => new UnprocessableEntityResult(),
            EndpointResultStatus.Duplicate => new ConflictResult(),
            EndpointResultStatus.Unauthorized => new UnauthorizedResult(),
            EndpointResultStatus.Gone => new StatusCodeResult((int)HttpStatusCode.Gone),
            _ => new StatusCodeResult((int)HttpStatusCode.InternalServerError)
        };
    }

    public static ActionResult ToActionResult<TResult>(this EndpointResult<TResult> endpointResult)
    {
        return endpointResult.Status switch
        {
            EndpointResultStatus.Success => new OkObjectResult(endpointResult.Data),
            _ => ((EndpointResult)endpointResult).ToActionResult()
        };
    }
}
