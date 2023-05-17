using Application.UseCases.UpdateGroup.Abstracts;
using Application.UseCases.UpdateGroup.Dtos;
using AutoMapper;
using Domain.Entities.Common;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases.UpdateGroup
{
    public class UpdateGroupUseCase : IUpdateGroupUseCase
    {
        private readonly CommonContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateGroupUseCase(CommonContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task UpdateAsync(UpdateGroupDto groupDto, CancellationToken cancellationToken)
        {
            var group = await _dbContext.Groups
               .Where(w => w.Uuid == groupDto.Uuid)
               .SingleAsync(cancellationToken);

            group.ChangeNameAndAlias(groupDto.Name, groupDto.Alias);

            _dbContext.Groups.Update(group);

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
