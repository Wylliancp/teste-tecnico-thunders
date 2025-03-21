using Microsoft.AspNetCore.Mvc;
using Thunders.TechTest.Application.Commands.Toll;
using Thunders.TechTest.Application.Handlers.Toll;
using Thunders.TechTest.Application.Queries.Toll;
using Thunders.TechTest.Domain.Commands;
using Thunders.TechTest.Domain.Queries;

namespace Thunders.TechTest.ApiService.Controllers;

[ApiController]
[Route("[controller]")]
public class TollController(ILogger<TollController> logger) : ControllerBase
{

    private readonly ILogger<TollController> _logger = logger;

    [Route("GetTById")]
    [HttpGet]

    public async Task<IQueryResult> GetById([FromQuery] GetByIdTollQuery query, [FromServices] TollQueryHandler handler)
    {
        return await handler.Handle(query);
    }

    [Route("GetAll")]
    [HttpGet]
    public async Task<IQueryResult> GetAll([FromQuery] GetAllTollQuery query, [FromServices] TollQueryHandler handler)
    {
        return await handler.Handle(query);
    }

    [Route("Create")]
    [HttpPost]

    public async Task<ICommandResult> Create([FromBody] CreateTollCommand command, [FromServices] TollCommandHandler handler)
    {
        return await handler.Handle(command);
    }
    

    [Route("Update")]
    [HttpPut]

    public async Task<ICommandResult> Update([FromBody] UpdateTollCommand command, [FromServices] TollCommandHandler handler)
    {
        return await handler.Handle(command);
    }


    [Route("Delete")]
    [HttpDelete]

    public async Task<ICommandResult> Delete([FromQuery] DeleteTollCommand command, [FromServices] TollCommandHandler handler)
    {
        return await handler.Handle(command);
    }


}
