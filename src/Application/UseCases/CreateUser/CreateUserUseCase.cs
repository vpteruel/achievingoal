using Application.UseCases.CreateUser.Abstracts;
using Application.UseCases.CreateUser.Dtos;
using AutoMapper;
using Domain.Entities.Common;
using Infrastructure;

namespace Application.UseCases.CreateUser
{
    public class CreateUserUseCase : ICreateUserUseCase
    {
        private readonly CommonContext _dbContext;
        private readonly IMapper _mapper;

        public CreateUserUseCase(CommonContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task CreateAsync(CreateUserDto userDto, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(userDto);

            await _dbContext.Users.AddAsync(user, cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
