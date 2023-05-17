using Application.UseCases.GetGroups.Abstracts;
using Application.UseCases.GetGroups.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.GetGroups
{
    [ApiController]
    [Route("api/v{version:apiVersion}/common/[controller]")]
    [ApiVersion("1.0")]
    public class GroupsController : ControllerBase
    {
        private readonly ILogger<GroupsController> _logger;
        private readonly IGetGroupsUseCase _useCase;

        public GroupsController(
            ILogger<GroupsController> logger
            , IGetGroupsUseCase useCase)
        {
            _logger = logger;
            _useCase = useCase;
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetGroupsDto>))]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var groups = await _useCase.GetAllAsync(cancellationToken);
            return Ok(groups);
        }
    }
}
