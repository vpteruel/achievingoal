using Application.UseCases.GetGroups.Abstracts;
using Application.UseCases.GetGroups.Dtos;
using AutoMapper;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases.GetGroups
{
    public class GetGroupsUseCase : IGetGroupsUseCase
    {
        private readonly CommonContext _dbContext;
        private readonly IMapper _mapper;

        public GetGroupsUseCase(CommonContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetGroupsDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            var groups = await _dbContext.Groups
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<GetGroupsDto>>(groups);
        }
    }
}
