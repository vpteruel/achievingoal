using Application.UseCases.GetGroupByUuid.Dtos;

namespace Application.UseCases.GetGroupByUuid.Abstracts
{
    public interface IGetGroupByUuidUseCase
    {
        Task<GetGroupByUuidDto> GetByUuidAsync(Guid uuid, CancellationToken cancellationToken);
    }
}