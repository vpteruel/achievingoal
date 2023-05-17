using Application.UseCases.GetGroupByUuid.Abstracts;
using Application.UseCases.GetGroupByUuid.Dtos;
using AutoMapper;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases.GetGroupByUuid
{
    public class GetGroupByUuidUseCase : IGetGroupByUuidUseCase
    {
        private readonly CommonContext _dbContext;
        private readonly IMapper _mapper;

        public GetGroupByUuidUseCase(CommonContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<GetGroupByUuidDto> GetByUuidAsync(Guid uuid, CancellationToken cancellationToken)
        {
            var group = await _dbContext.Groups
                .Where(w => w.Uuid == uuid)
                .SingleOrDefaultAsync(cancellationToken);

            return _mapper.Map<GetGroupByUuidDto>(group);
        }
    }
}
