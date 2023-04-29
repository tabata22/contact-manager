using ContactManager.Application.ContactManager.Create;
using ContactManager.Application.ContactManager.Delete;
using ContactManager.Application.ContactManager.Get;
using ContactManager.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ContactManager.Api.Controllers;

[ApiController]
[Route("v1/ContactManager")]
public class ContactManagerController : ControllerBase
{
    private readonly IMediator _mediator;

    public ContactManagerController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("GetAll")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyCollection<ContactManagerEntity>>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var query = new GetAllQuery();
        var contactManager = await _mediator.Send(query, cancellationToken);

        return Ok(contactManager);
    }
    
    [HttpGet("GetById")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<ContactManagerEntity>> GetByIdAsync([FromQuery] GetByIdQuery query, CancellationToken cancellationToken = default)
    {
        var contactManager = await _mediator.Send(query, cancellationToken);

        return Ok(contactManager);
    }

    [HttpPut("Put")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> PutAsync([FromBody] PutContactManagerCommand command, CancellationToken cancellationToken = default)
    {
        await _mediator.Send(command, cancellationToken);

        return Ok();
    }

    [HttpDelete("Delete")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateAsync([FromQuery] DeleteContactManagerCommand command, CancellationToken cancellationToken = default)
    {
        await _mediator.Send(command, cancellationToken);

        return Ok();
    }
}