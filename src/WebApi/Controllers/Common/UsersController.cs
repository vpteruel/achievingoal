using Domain.Entities.Common;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers.Common
{
    [ApiController]
    [Route("api/v{version:apiVersion}/common/[controller]")]
    [ApiVersion("1.0")]
    [ApiVersion("2.0", Deprecated = true)]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly CommonContext _dbContext;

        public UsersController(
            ILogger<UsersController> logger
            , CommonContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        public async Task<IEnumerable<User>> GetAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }

        [HttpGet]
        [MapToApiVersion("2.0")]
        public IEnumerable<User> Get()
        {
            return Enumerable.Range(1, 5).Select(index =>
            {
                var value = Random.Shared.Next(1, 99);
                return new User($"Fake Name {value}", $"fake-email-{value}@main-group.ca");
            }).ToArray();
        }
    }
}
