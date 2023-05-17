using Application.UseCases.GetGroupByUuid.Abstracts;
using Application.UseCases.GetGroupByUuid.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.GetGroupByUuid
{
    [ApiController]
    [Route("api/v{version:apiVersion}/common/[controller]")]
    [ApiVersion("1.0")]
    public class GroupsController : ControllerBase
    {
        private readonly ILogger<GroupsController> _logger;
        private readonly IGetGroupByUuidUseCase _useCase;

        public GroupsController(
            ILogger<GroupsController> logger
            , IGetGroupByUuidUseCase useCase)
        {
            _logger = logger;
            _useCase = useCase;
        }

        [HttpGet("{uuid}")]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetGroupByUuidDto))]
        public async Task<IActionResult> GetByUuidAsync(Guid uuid, CancellationToken cancellationToken)
        {
            var group = await _useCase.GetByUuidAsync(uuid, cancellationToken);
            return Ok(group);
        }
    }
}
