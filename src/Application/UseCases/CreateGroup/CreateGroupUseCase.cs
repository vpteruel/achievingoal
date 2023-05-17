using Application.UseCases.CreateGroup.Abstracts;
using Application.UseCases.CreateGroup.Dtos;
using AutoMapper;
using Domain.Entities.Common;
using Infrastructure;

namespace Application.UseCases.CreateGroup
{
    public class CreateGroupUseCase : ICreateGroupUseCase
    {
        private readonly CommonContext _dbContext;
        private readonly IMapper _mapper;

        public CreateGroupUseCase(CommonContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task CreateAsync(CreateGroupDto groupDto, CancellationToken cancellationToken)
        {
            var group = new Group(groupDto.Name, groupDto.Alias);

            // var group2 = _mapper.Map<Group>(groupDto);

            await _dbContext.Groups.AddAsync(group, cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
